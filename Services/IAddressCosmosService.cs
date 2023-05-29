using Dot6.API.CosmosDB.Demo.Models;

namespace Dot6.API.CosmosDB.Demo.Services;

public interface IAddressCosmosService
{
    Task<List<Address>> Get(string sqlCosmosQuery);
    Task<Address> AddAsync(Address newaddress);
    Task<Address> Update(Address addressToUpdate);
    Task Delete(string id, string customerId);
}