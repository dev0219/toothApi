using Dot6.API.CosmosDB.Demo.Models;
using Dot6.API.CosmosDB.Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dot6.API.CosmosDB.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientsController : ControllerBase
{
    public readonly IPatientCosmosService _patientsCosmosService;
    public readonly ITelephoneCosmosService _telephoneCosmosService;
    public PatientsController(IPatientCosmosService patientsCosmosService, ITelephoneCosmosService telephoneCosmosService)
    {
        _patientsCosmosService = patientsCosmosService;
        _telephoneCosmosService = telephoneCosmosService;
    }

    [HttpGet("All")]
    public async Task<IActionResult> Get()
    {
        var sqlCosmosQuery = "Select * from c";
        var result = await _patientsCosmosService.Get(sqlCosmosQuery);
        return Ok(result);
    }

    [HttpGet("SearchByName")]
    public async Task<IActionResult> SearchByName(string name)
    {
        var sqlCosmosQuery = "SELECT * FROM c WHERE c.firstName = @name OR c.lastName = @name OR c.surName = @name";
        var result = await _patientsCosmosService.SearchByName(sqlCosmosQuery, name);
        return Ok(result);
    }

    [HttpGet("SearchBy-Docu-Site-Id")]
    public async Task<IActionResult> SearchById(string Id)
    {
        var sqlCosmosQuery = "SELECT * FROM c WHERE c.documentId = @Id OR c.siteId = @Id";
        var result = await _patientsCosmosService.SearchById(sqlCosmosQuery, Id);
        return Ok(result);
    }

    [HttpGet("SearchByPhone")]
    public async Task<IActionResult> SearchByPhone(string Phone)
    {
        var sqlCosmosQueryPatient = "Select * from c";
        var result_patients = await _patientsCosmosService.Get(sqlCosmosQueryPatient);

        var sqlCosmosQueryTelephone = "SELECT * FROM c WHERE c.number = @Phone";
        var result_telephone = await _telephoneCosmosService.SearchByPhone(sqlCosmosQueryTelephone, Phone);


        var results = from p in result_patients
                        join t in result_telephone on p.Id equals t.PatientId
                        select new Patients
                        {
                            Id = p.Id,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            SurName = p.SurName,
                            SecondLastName = p.SecondLastName,
                            BirthDate = p.BirthDate,
                            Gender = p.Gender,
                            AvailableFrom = p.AvailableFrom,
                            AvailableUntil = p.AvailableUntil,
                            BirthPlace = p.BirthPlace,
                            JobTitle = p.JobTitle,
                            DocumentIdType = p.DocumentIdType,
                            DocumentId = p.DocumentId,
                            SiteId = p.SiteId,
                            ClientId = p.ClientId,
                            Email = p.Email,
                            CustomerId = p.CustomerId,
                            UserCreated = p.UserCreated,
                            CreatedUtc = p.CreatedUtc,
                            UserModified = p.UserModified,
                            ModifiedOnUtc = p.ModifiedOnUtc
                        };

        return Ok(results);
    }    

    [HttpPost("Create")]
    public async Task<IActionResult> Post(Patients newPatient)
    {
        newPatient.Id = Guid.NewGuid().ToString();
        newPatient.CreatedUtc = DateTime.UtcNow.ToString("o");
        newPatient.ModifiedOnUtc = DateTime.UtcNow.ToString("o");
        var result = await _patientsCosmosService.AddAsync(newPatient);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Put(Patients patientToUpdate)
    {
        patientToUpdate.ModifiedOnUtc = DateTime.UtcNow.ToString("o");
        var result = await _patientsCosmosService.Update(patientToUpdate);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(string id, string customerId)
    {
        await _patientsCosmosService.Delete(id, customerId);
        return Ok();
    }

}