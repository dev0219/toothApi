using Newtonsoft.Json;

namespace Dot6.API.CosmosDB.Demo.Models;

public class Address
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("entityType")]
    public string EntityType { get; set; }
    [JsonProperty("patientId")]
    public string PatientId { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("area")]
    public string Area { get; set; }
    [JsonProperty("mainStreet")]
    public string MainStreet { get; set; }
    [JsonProperty("number")]
    public string Number { get; set; }
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

