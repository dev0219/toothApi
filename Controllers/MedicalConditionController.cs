using toothApi.Models;
using toothApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace toothApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicalConditionController : ControllerBase
{
    public readonly IMedicalConditionCosmosService _medicalConditionCosmosService;
    public MedicalConditionController(IMedicalConditionCosmosService medicalConditionCosmosService)
    {
        _medicalConditionCosmosService = medicalConditionCosmosService;
    }

    [HttpGet("All")]
    public async Task<IActionResult> Get()
    {
        var sqlCosmosQuery = "Select * from c";
        var result = await _medicalConditionCosmosService.Get(sqlCosmosQuery);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Post(MedicalCondition newMedicalCondition)
    {
        newMedicalCondition.Id = Guid.NewGuid().ToString();
        newMedicalCondition.CreatedUtc = DateTime.UtcNow.ToString("o");
        newMedicalCondition.ModifiedOnUtc = DateTime.UtcNow.ToString("o");
        var result = await _medicalConditionCosmosService.AddAsync(newMedicalCondition);
        return Ok(result);
    }

    [HttpGet("getMedicalCondition")]
    public async Task<IActionResult> GetById(string Id)
    {
        var sqlCosmosQuery = "SELECT * FROM c WHERE c.id = @Id";
        var result = await _medicalConditionCosmosService.SearchById(sqlCosmosQuery, Id);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Put(MedicalCondition medicalConditionToUpdate)
    {
        medicalConditionToUpdate.ModifiedOnUtc = DateTime.UtcNow.ToString("o");
        var result = await _medicalConditionCosmosService.Update(medicalConditionToUpdate);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(string id, string customerId)
    {
        await _medicalConditionCosmosService.Delete(id, customerId);
        return Ok();
    }

}