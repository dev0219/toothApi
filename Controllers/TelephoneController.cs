using Dot6.API.CosmosDB.Demo.Models;
using Dot6.API.CosmosDB.Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dot6.API.CosmosDB.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class TelephoneController : ControllerBase
{
    public readonly ITelephoneCosmosService _telephoneCosmosService;
    public TelephoneController(ITelephoneCosmosService telephoneCosmosService)
    {
        _telephoneCosmosService = telephoneCosmosService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var sqlCosmosQuery = "Select * from c";
        var result = await _telephoneCosmosService.Get(sqlCosmosQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Telephone newTelephone)
    {
        newTelephone.Id = Guid.NewGuid().ToString();
        var result = await _telephoneCosmosService.AddAsync(newTelephone);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Telephone telephoneToUpdate)
    {
        var result = await _telephoneCosmosService.Update(telephoneToUpdate);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id, string customerId)
    {
        await _telephoneCosmosService.Delete(id, customerId);
        return Ok();
    }

}