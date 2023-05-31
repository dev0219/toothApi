using toothApi.Models;

namespace toothApi.Services;

public interface INoteCosmosService
{
    Task<List<Note>> Get(string sqlCosmosQuery);
    Task<List<Note>> SearchById(string sqlCosmosQuery, string Id);
    Task<Note> AddAsync(Note newNote);
    Task<Note> Update(Note noteToUpdate);
    Task Delete(string id, string customerId);
}