using toothApi.Models;
using toothApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace toothApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TelephoneController : ControllerBase
{
    public readonly ITelephoneCosmosService _telephoneCosmosService;
    public TelephoneController(ITelephoneCosmosService telephoneCosmosService)
    {
        _telephoneCosmosService = telephoneCosmosService;
    }

    [HttpGet("All")]
    public async Task<IActionResult> Get()
    {
        var sqlCosmosQuery = "Select * from c";
        var result = await _telephoneCosmosService.Get(sqlCosmosQuery);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Post(Telephone newTelephone)
    {
        newTelephone.Id = Guid.NewGuid().ToString();
        newTelephone.CreatedUtc = DateTime.UtcNow.ToString("o");
        newTelephone.ModifiedOnUtc = DateTime.UtcNow.ToString("o");
        var result = await _telephoneCosmosService.AddAsync(newTelephone);
        return Ok(result);
    }

    [HttpGet("getPhoneInfo")]
    public async Task<IActionResult> GetById(string Id)
    {
        var sqlCosmosQuery = "SELECT * FROM c WHERE c.id = @Id";
        var result = await _telephoneCosmosService.SearchById(sqlCosmosQuery, Id);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Put(Telephone telephoneToUpdate)
    {
        telephoneToUpdate.ModifiedOnUtc = DateTime.UtcNow.ToString("o");
        var result = await _telephoneCosmosService.Update(telephoneToUpdate);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(string id, string customerId)
    {
        await _telephoneCosmosService.Delete(id, customerId);
        return Ok();
    }

}