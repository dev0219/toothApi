using toothApi.Models;
using Microsoft.Azure.Cosmos;

namespace toothApi.Services;

public class MedicalConditionCosmosService : IMedicalConditionCosmosService
{
    private readonly Container _container;
    public MedicalConditionCosmosService(CosmosClient cosmosClient,
    string databaseName,
    string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }

    public async Task<List<MedicalCondition>> Get(string sqlCosmosQuery)
    {
        var query = _container.GetItemQueryIterator<MedicalCondition>(new QueryDefinition(sqlCosmosQuery));

        List<MedicalCondition> result = new List<MedicalCondition>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            result.AddRange(response);
        }

        return result;
    }

    public async Task<List<MedicalCondition>> SearchById(string sqlCosmosQuery, string Id)
    {
        List<MedicalCondition> result = new List<MedicalCondition>();

        QueryDefinition queryDefinition = new QueryDefinition(sqlCosmosQuery)
            .WithParameter("@Id", Id);

        FeedIterator<MedicalCondition> feedIterator = _container.GetItemQueryIterator<MedicalCondition>(queryDefinition);

        while (feedIterator.HasMoreResults)
        {
            FeedResponse<MedicalCondition> response = await feedIterator.ReadNextAsync();
            result.AddRange(response.ToList());
        }

        return result;
    }

    public async Task<MedicalCondition> AddAsync(MedicalCondition newMedicalCondition)
    {
        var item = await _container.CreateItemAsync<MedicalCondition>(newMedicalCondition, new PartitionKey(newMedicalCondition.CustomerId));
        return item;
    }

    public async Task<MedicalCondition> Update(MedicalCondition medicalConditionToUpdate)
    {
        var item = await _container.UpsertItemAsync<MedicalCondition>(medicalConditionToUpdate, new PartitionKey(medicalConditionToUpdate.CustomerId));
        return item;
    }

    public async Task Delete(string id, string customerId)
    {
        await _container.DeleteItemAsync<MedicalCondition>(id, new PartitionKey(customerId));
    }
}