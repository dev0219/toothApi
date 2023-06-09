using toothApi.Models;
using Microsoft.Azure.Cosmos;

namespace toothApi.Services;

public class TelephoneCosmosService : ITelephoneCosmosService
{
    private readonly Container _container;
    public TelephoneCosmosService(CosmosClient cosmosClient,
    string databaseName,
    string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }

    public async Task<List<Telephone>> Get(string sqlCosmosQuery)
    {
        var query = _container.GetItemQueryIterator<Telephone>(new QueryDefinition(sqlCosmosQuery));

        List<Telephone> result = new List<Telephone>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            result.AddRange(response);
        }

        return result;
    }

    public async Task<List<Telephone>> SearchByPhone(string sqlCosmosQuery, string Phone)
    {
        List<Telephone> result = new List<Telephone>();

        QueryDefinition queryDefinition = new QueryDefinition(sqlCosmosQuery)
            .WithParameter("@Phone", Phone);

        FeedIterator<Telephone> feedIterator = _container.GetItemQueryIterator<Telephone>(queryDefinition);

        while (feedIterator.HasMoreResults)
        {
            FeedResponse<Telephone> response = await feedIterator.ReadNextAsync();
            result.AddRange(response.ToList());
        }

        return result;
    }

    public async Task<List<Telephone>> SearchById(string sqlCosmosQuery, string Id)
    {
        List<Telephone> result = new List<Telephone>();

        QueryDefinition queryDefinition = new QueryDefinition(sqlCosmosQuery)
            .WithParameter("@Id", Id);

        FeedIterator<Telephone> feedIterator = _container.GetItemQueryIterator<Telephone>(queryDefinition);

        while (feedIterator.HasMoreResults)
        {
            FeedResponse<Telephone> response = await feedIterator.ReadNextAsync();
            result.AddRange(response.ToList());
        }

        return result;
    }

    public async Task<Telephone> AddAsync(Telephone newTelephone)
    {
        var item = await _container.CreateItemAsync<Telephone>(newTelephone, new PartitionKey(newTelephone.CustomerId));
        return item;
    }

    public async Task<Telephone> Update(Telephone telephoneToUpdate)
    {
        var item = await _container.UpsertItemAsync<Telephone>(telephoneToUpdate, new PartitionKey(telephoneToUpdate.CustomerId));
        return item;
    }

    public async Task Delete(string id, string customerId)
    {
        await _container.DeleteItemAsync<Telephone>(id, new PartitionKey(customerId));
    }
}