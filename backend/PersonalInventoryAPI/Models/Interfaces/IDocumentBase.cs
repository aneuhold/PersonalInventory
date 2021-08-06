using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonalInventoryAPI.Models.Interfaces {
  public abstract class IDocumentBase {

    [BsonId]
    public ObjectId Id { get; set; }
  }
}
