using toothApi.Models;

namespace toothApi.Services;

public interface IMedicalConditionCosmosService
{
    Task<List<MedicalCondition>> Get(string sqlCosmosQuery);
    Task<List<MedicalCondition>> SearchById(string sqlCosmosQuery, string Id);
    Task<MedicalCondition> AddAsync(MedicalCondition newMedicalCondition);
    Task<MedicalCondition> Update(MedicalCondition medicalConditionToUpdate);
    Task Delete(string id, string customerId);
}