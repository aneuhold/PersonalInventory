
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace PersonalInventoryAPI.Contexts {
  public class MongoDbContext {
    private const string DATABASE_NAME = "PersonalInventory";

    public readonly MongoClient _client;
    public readonly IMongoDatabase _database;
    private readonly IConfiguration _configuration;

    public MongoDbContext(IConfiguration configuration) {
      _configuration = configuration;
      var settings = MongoClientSettings.FromConnectionString(GetConnectionString());
      _client = new MongoClient(settings);
      _database = _client.GetDatabase(DATABASE_NAME);
    }

    private string GetConnectionString() {
      try {
        return _configuration["MongoDbSettings:ConnectionString"];
      } catch (Exception) {
        Console.WriteLine($"Error getting the MongoDB connection string");
        throw;
      }
    }
  }
}
