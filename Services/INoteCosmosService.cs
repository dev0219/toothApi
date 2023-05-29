using Dot6.API.CosmosDB.Demo.Models;

namespace Dot6.API.CosmosDB.Demo.Services;

public interface INoteCosmosService
{
    Task<List<Note>> Get(string sqlCosmosQuery);
    Task<Note> AddAsync(Note newNote);
    Task<Note> Update(Note noteToUpdate);
    Task Delete(string id, string customerId);
}