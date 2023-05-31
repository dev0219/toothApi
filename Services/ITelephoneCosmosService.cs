using toothApi.Models;

namespace toothApi.Services;

public interface ITelephoneCosmosService
{
    Task<List<Telephone>> Get(string sqlCosmosQuery);
    Task<List<Telephone>> SearchByPhone(string sqlCosmosQuery, string Phone);
    Task<List<Telephone>> SearchById(string sqlCosmosQuery, string Id);
    Task<Telephone> AddAsync(Telephone newTelephone);
    Task<Telephone> Update(Telephone telephoneToUpdate);
    Task Delete(string id, string customerId);
}