using Dot6.API.CosmosDB.Demo.Models;
using Dot6.API.CosmosDB.Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dot6.API.CosmosDB.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    public readonly IAddressCosmosService _addressCosmosService;
    public AddressController(IAddressCosmosService addressCosmosService)
    {
        _addressCosmosService = addressCosmosService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var sqlCosmosQuery = "Select * from c";
        var result = await _addressCosmosService.Get(sqlCosmosQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Address newAddress)
    {
        newAddress.Id = Guid.NewGuid().ToString();
        var result = await _addressCosmosService.AddAsync(newAddress);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Address addressToUpdate)
    {
        var result = await _addressCosmosService.Update(addressToUpdate);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id, string customerId)
    {
        await _addressCosmosService.Delete(id, customerId);
        return Ok();
    }

}