using toothApi.Models;

namespace toothApi.Services;

public interface IPatientCosmosService
{
    Task<List<Patients>> Get(string sqlCosmosQuery);
    Task<List<Patients>> SearchByName(string sqlCosmosQuery, string name);
    Task<List<Patients>> SearchById(string sqlCosmosQuery, string Id);
    Task<List<Patients>> RecentPatients(string sqlCosmosQuery);
    Task<Patients> AddAsync(Patients newPatient);
    Task<Patients> Update(Patients PatientToUpdate);
    Task Delete(string id, string customerId);
}