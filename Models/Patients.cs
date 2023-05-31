using Newtonsoft.Json;

namespace toothApi.Models;

public class Patients
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("firstName")]
    public string FirstName { get; set; }
    [JsonProperty("lastName")]
    public string LastName { get; set; }
    [JsonProperty("surName")]
    public string SurName { get; set; }
    [JsonProperty("secondLastName")]
    public string SecondLastName { get; set; }
    [JsonProperty("birthDate")]
    public string BirthDate { get; set; }
    [JsonProperty("gender")]
    public string Gender { get; set; }
    [JsonProperty("availableFrom")]
    public string AvailableFrom { get; set; }
    [JsonProperty("availableUntil")]
    public string AvailableUntil { get; set; }
    [JsonProperty("birthPlace")]
    public string BirthPlace { get; set; }
    [JsonProperty("jobTitle")]
    public string JobTitle { get; set; }
    [JsonProperty("documentIdType")]
    public string DocumentIdType { get; set; }
    [JsonProperty("documentId")]
    public string DocumentId { get; set; }
    [JsonProperty("siteId")]
    public string SiteId { get; set; }
    [JsonProperty("clientId")]
    public string ClientId { get; set; }
    [JsonProperty("email")]
    public string Email { get; set; }
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

