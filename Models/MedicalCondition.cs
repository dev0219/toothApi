using Newtonsoft.Json;

namespace Dot6.API.CosmosDB.Demo.Models;

public class MedicalCondition
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("entityType")]
    public string EntityType { get; set; }
    [JsonProperty("patientId")]
    public string PatientId { get; set; }
    [JsonProperty("diseases")]
    public bool Diseases { get; set; }
    [JsonProperty("diseasesDescription")]
    public string DiseasesDescription { get; set; }
    [JsonProperty("treatment")]
    public bool Treatment { get; set; }
    [JsonProperty("treatmentDescription")]
    public string TreatmentDescription { get; set; }
    [JsonProperty("highBloodPressure")]
    public bool HighBloodPressure { get; set; }
    [JsonProperty("heartDisease")]
    public bool HeartDisease { get; set; }
    [JsonProperty("heartDiseaseDescription")]
    public string HeartDiseaseDescription { get; set; }
    [JsonProperty("diabetes")]
    public bool Diabetes { get; set; }
    [JsonProperty("pregnancy")]
    public bool Pregnancy { get; set; }
    [JsonProperty("surgery")]
    public bool Surgery { get; set; }
    [JsonProperty("surgeryDescription")]
    public string SurgeryDescription { get; set; }
    [JsonProperty("gingivitis")]
    public bool Gingivitis { get; set; }
    [JsonProperty("gumDiseases")]
    public bool GumDiseases { get; set; }
    [JsonProperty("allergies")]
    public bool Allergies { get; set; }
    [JsonProperty("allergiesDescription")]
    public string AllergiesDescription { get; set; }
    [JsonProperty("siteId")]
    public string SiteId { get; set; }
    [JsonProperty("clientId")]
    public string ClientId { get; set; }
    [JsonProperty("customerId")]
    public string CustomerId { get; set; }
    [JsonProperty("userCreated")]
    public string UserCreated { get; set; }
    [JsonProperty("creatOnUtc")]
    public string CreatedUtc { get; set; }
    [JsonProperty("userModified")]
    public string UserModified { get; set; }
    [JsonProperty("modifiedOnUtc")]
    public string ModifiedOnUtc { get; set; }
}

