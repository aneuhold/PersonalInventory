using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonalInventoryAPI.Models.Interfaces {
  public abstract class IDocumentBase {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; protected set; }
  }
}
