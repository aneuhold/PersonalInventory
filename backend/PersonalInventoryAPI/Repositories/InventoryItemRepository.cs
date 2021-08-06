using MongoDB.Bson;
using MongoDB.Driver;
using PersonalInventoryAPI.Contexts;
using PersonalInventoryAPI.Models;
using PersonalInventoryAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalInventoryAPI.Repositories {
  public class InventoryItemRepository : IInventoryItemRepository {
    private readonly MongoDbContext _dbContext;
    private readonly IMongoCollection<InventoryItem> _itemsCollection;

    public InventoryItemRepository(MongoDbContext dbContext) {
      _dbContext = dbContext;
      _itemsCollection = _dbContext._database.GetCollection<InventoryItem>("InventoryItem");
    }

    async public Task<InventoryItem> CreateOne(InventoryItem newDoc) {
      await _itemsCollection.InsertOneAsync(newDoc);
      return newDoc;
    }

    async public Task<long> DeleteAllAsync() {
      var deleteResult = await _itemsCollection.DeleteManyAsync(_ => true);
      return deleteResult.DeletedCount;
    }

    async public Task<IList<InventoryItem>> GetAllAsync() {
      return await _itemsCollection.Find(_ => true).ToListAsync();
    }

    async public Task<InventoryItem> GetByIdAsync(ObjectId id) {
      return await _itemsCollection.FindAsync(doc => doc.Id == id).Result.FirstAsync();
    }

    async public Task SetByIdAsync(InventoryItem newDoc, ObjectId id) {
      await _itemsCollection.ReplaceOneAsync(doc => doc.Id == id, newDoc);
    }
  }
}
