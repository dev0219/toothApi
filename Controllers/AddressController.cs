using toothApi.Models;
using toothApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace toothApi.Controllers;

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

    [HttpGet("getAddress")]
    public async Task<IActionResult> GetById(string Id)
    {
        var sqlCosmosQuery = "SELECT * FROM c WHERE c.id = @Id";
        var result = await _addressCosmosService.SearchById(sqlCosmosQuery, Id);
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