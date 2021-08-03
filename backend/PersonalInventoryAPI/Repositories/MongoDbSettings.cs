using PersonalInventoryAPI.Repositories.Interfaces;

namespace PersonalInventoryAPI.Repositories {
  public class MongoDbSettings : IMongoDbSettings {
    public string ConnectionString { get; set; }
  }
}
