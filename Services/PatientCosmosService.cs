using toothApi.Models;
using Microsoft.Azure.Cosmos;

namespace toothApi.Services;

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

    public async Task<List<Patients>> RecentPatients(string sqlCosmosQuery)
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

    public async Task<List<Patients>> SearchByName(string sqlCosmosQuery, string name)
    {
        List<Patients> result = new List<Patients>();

        QueryDefinition queryDefinition = new QueryDefinition(sqlCosmosQuery)
            .WithParameter("@name", name);

        FeedIterator<Patients> feedIterator = _container.GetItemQueryIterator<Patients>(queryDefinition);

        while (feedIterator.HasMoreResults)
        {
            FeedResponse<Patients> response = await feedIterator.ReadNextAsync();
            result.AddRange(response.ToList());
        }

        return result;
    }

    public async Task<List<Patients>> SearchById(string sqlCosmosQuery, string Id)
    {
        List<Patients> result = new List<Patients>();

        QueryDefinition queryDefinition = new QueryDefinition(sqlCosmosQuery)
            .WithParameter("@Id", Id);

        FeedIterator<Patients> feedIterator = _container.GetItemQueryIterator<Patients>(queryDefinition);

        while (feedIterator.HasMoreResults)
        {
            FeedResponse<Patients> response = await feedIterator.ReadNextAsync();
            result.AddRange(response.ToList());
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