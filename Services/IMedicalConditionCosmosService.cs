using Dot6.API.CosmosDB.Demo.Models;

namespace Dot6.API.CosmosDB.Demo.Services;

public interface IMedicalConditionCosmosService
{
    Task<List<MedicalCondition>> Get(string sqlCosmosQuery);
    Task<MedicalCondition> AddAsync(MedicalCondition newMedicalCondition);
    Task<MedicalCondition> Update(MedicalCondition medicalConditionToUpdate);
    Task Delete(string id, string customerId);
}