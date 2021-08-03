using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace PersonalInventoryAPI.Models.Interfaces {
  public abstract class IInventoryItem : IDocumentBase {
    [BsonElement("name")]
    [JsonProperty("name")]
    public string Name { get; set; }
    [BsonElement("location")]
    [JsonProperty("location")]
    public string Location { get; set; }
  }
}
