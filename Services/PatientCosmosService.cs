using Dot6.API.CosmosDB.Demo.Models;
using Microsoft.Azure.Cosmos;

namespace Dot6.API.CosmosDB.Demo.Services;

public class PatientCosmosService : IPatientCosmosService
{
    private readonly Container _container;
    public PatientCosmosService(CosmosClient cosmosClient,
    string databaseName,
    string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }

    public async Task<List<Patients>> Get(string sqlCosmosQuery)
    {
        var query = _container.GetItemQueryIterator<Patients>(new QueryDefinition(sqlCosmosQuery));

        List<Patients> result = new List<Patients>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            result.AddRange(response);
        }

        return result;
    }

    public async Task<Patients> AddAsync(Patients newPatient)
    {
        var item = await _container.CreateItemAsync<Patients>(newPatient, new PartitionKey(newPatient.CustomerId));
        return item;
    }

    public async Task<Patients> Update(Patients patientToUpdate)
    {
        var item = await _container.UpsertItemAsync<Patients>(patientToUpdate, new PartitionKey(patientToUpdate.CustomerId));
        return item;
    }

    public async Task Delete(string id, string customerId)
    {
        await _container.DeleteItemAsync<Patients>(id, new PartitionKey(customerId));
    }
}