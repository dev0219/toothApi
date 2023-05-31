using toothApi.Models;

namespace toothApi.Services;

public interface IAddressCosmosService
{
    Task<List<Address>> Get(string sqlCosmosQuery);
    Task<List<Address>> SearchById(string sqlCosmosQuery, string Id);
    Task<Address> AddAsync(Address newaddress);
    Task<Address> Update(Address addressToUpdate);
    Task Delete(string id, string customerId);
}