using Dot6.API.CosmosDB.Demo.Models;

namespace Dot6.API.CosmosDB.Demo.Services;

public interface IPatientCosmosService
{
    Task<List<Patients>> Get(string sqlCosmosQuery);
    Task<List<Patients>> SearchByName(string sqlCosmosQuery, string name);
    Task<List<Patients>> SearchById(string sqlCosmosQuery, string Id);
    Task<Patients> AddAsync(Patients newPatient);
    Task<Patients> Update(Patients PatientToUpdate);
    Task Delete(string id, string customerId);
}