using Dot6.API.CosmosDB.Demo.Models;

namespace Dot6.API.CosmosDB.Demo.Services;

public interface ITelephoneCosmosService
{
    Task<List<Telephone>> Get(string sqlCosmosQuery);
    Task<Telephone> AddAsync(Telephone newTelephone);
    Task<Telephone> Update(Telephone telephoneToUpdate);
    Task Delete(string id, string customerId);
}