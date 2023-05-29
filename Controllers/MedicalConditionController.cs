using Dot6.API.CosmosDB.Demo.Models;
using Dot6.API.CosmosDB.Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dot6.API.CosmosDB.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicalConditionController : ControllerBase
{
    public readonly IMedicalConditionCosmosService _medicalConditionCosmosService;
    public MedicalConditionController(IMedicalConditionCosmosService medicalConditionCosmosService)
    {
        _medicalConditionCosmosService = medicalConditionCosmosService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var sqlCosmosQuery = "Select * from c";
        var result = await _medicalConditionCosmosService.Get(sqlCosmosQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(MedicalCondition newMedicalCondition)
    {
        newMedicalCondition.Id = Guid.NewGuid().ToString();
        var result = await _medicalConditionCosmosService.AddAsync(newMedicalCondition);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(MedicalCondition medicalConditionToUpdate)
    {
        var result = await _medicalConditionCosmosService.Update(medicalConditionToUpdate);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id, string customerId)
    {
        await _medicalConditionCosmosService.Delete(id, customerId);
        return Ok();
    }

}