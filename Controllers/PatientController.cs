using Dot6.API.CosmosDB.Demo.Models;
using Dot6.API.CosmosDB.Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dot6.API.CosmosDB.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientsController : ControllerBase
{
    public readonly IPatientCosmosService _patientsCosmosService;
    public PatientsController(IPatientCosmosService patientsCosmosService)
    {
        _patientsCosmosService = patientsCosmosService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var sqlCosmosQuery = "Select * from c";
        var result = await _patientsCosmosService.Get(sqlCosmosQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Patients newPatient)
    {
        newPatient.Id = Guid.NewGuid().ToString();
        var result = await _patientsCosmosService.AddAsync(newPatient);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Patients patientToUpdate)
    {
        var result = await _patientsCosmosService.Update(patientToUpdate);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id, string customerId)
    {
        await _patientsCosmosService.Delete(id, customerId);
        return Ok();
    }

}