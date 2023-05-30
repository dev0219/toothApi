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

    [HttpGet("All")]
    public async Task<IActionResult> Get()
    {
        var sqlCosmosQuery = "Select * from c";
        var result = await _addressCosmosService.Get(sqlCosmosQuery);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Post(Address newAddress)
    {
        newAddress.Id = Guid.NewGuid().ToString();
        newAddress.CreatedUtc = DateTime.UtcNow.ToString("o");
        newAddress.ModifiedOnUtc = DateTime.UtcNow.ToString("o");
        var result = await _addressCosmosService.AddAsync(newAddress);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Put(Address addressToUpdate)
    {
        addressToUpdate.ModifiedOnUtc = DateTime.UtcNow.ToString("o");
        var result = await _addressCosmosService.Update(addressToUpdate);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(string id, string customerId)
    {
        await _addressCosmosService.Delete(id, customerId);
        return Ok();
    }

}