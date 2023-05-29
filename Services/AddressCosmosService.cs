using Dot6.API.CosmosDB.Demo.Models;
using Microsoft.Azure.Cosmos;

namespace Dot6.API.CosmosDB.Demo.Services;

public class AddressCosmosService : IAddressCosmosService
{
    private readonly Container _container;
    public AddressCosmosService(CosmosClient cosmosClient,
    string databaseName,
    string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }

    public async Task<List<Address>> Get(string sqlCosmosQuery)
    {
        var query = _container.GetItemQueryIterator<Address>(new QueryDefinition(sqlCosmosQuery));

        List<Address> result = new List<Address>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            result.AddRange(response);
        }

        return result;
    }

    public async Task<Address> AddAsync(Address newAddress)
    {
        var item = await _container.CreateItemAsync<Address>(newAddress, new PartitionKey(newAddress.CustomerId));
        return item;
    }

    public async Task<Address> Update(Address addressToUpdate)
    {
        var item = await _container.UpsertItemAsync<Address>(addressToUpdate, new PartitionKey(addressToUpdate.CustomerId));
        return item;
    }

    public async Task Delete(string id, string customerId)
    {
        await _container.DeleteItemAsync<Address>(id, new PartitionKey(customerId));
    }
}