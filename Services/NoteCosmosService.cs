using toothApi.Models;
using Microsoft.Azure.Cosmos;

namespace toothApi.Services;

public class NoteCosmosService : INoteCosmosService
{
    private readonly Container _container;
    public NoteCosmosService(CosmosClient cosmosClient,
    string databaseName,
    string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }

    public async Task<List<Note>> Get(string sqlCosmosQuery)
    {
        var query = _container.GetItemQueryIterator<Note>(new QueryDefinition(sqlCosmosQuery));

        List<Note> result = new List<Note>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            result.AddRange(response);
        }

        return result;
    }

    public async Task<List<Note>> SearchById(string sqlCosmosQuery, string Id)
    {
        List<Note> result = new List<Note>();

        QueryDefinition queryDefinition = new QueryDefinition(sqlCosmosQuery)
            .WithParameter("@Id", Id);

        FeedIterator<Note> feedIterator = _container.GetItemQueryIterator<Note>(queryDefinition);

        while (feedIterator.HasMoreResults)
        {
            FeedResponse<Note> response = await feedIterator.ReadNextAsync();
            result.AddRange(response.ToList());
        }

        return result;
    }

    public async Task<Note> AddAsync(Note newNote)
    {
        var item = await _container.CreateItemAsync<Note>(newNote, new PartitionKey(newNote.CustomerId));
        return item;
    }

    public async Task<Note> Update(Note noteToUpdate)
    {
        var item = await _container.UpsertItemAsync<Note>(noteToUpdate, new PartitionKey(noteToUpdate.CustomerId));
        return item;
    }

    public async Task Delete(string id, string customerId)
    {
        await _container.DeleteItemAsync<Note>(id, new PartitionKey(customerId));
    }
}