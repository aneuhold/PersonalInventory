using MongoDB.Bson;
using MongoDB.Driver;
using PersonalInventoryAPI.Contexts;
using PersonalInventoryAPI.Models.Interfaces;
using PersonalInventoryAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalInventoryAPI.Repositories {
  public class InventoryItemRepository : IInventoryItemRepository {
    private readonly MongoDbContext _dbContext;
    private readonly IMongoCollection<IInventoryItem> _itemsCollection;

    public InventoryItemRepository(MongoDbContext dbContext) {
      _dbContext = dbContext;
      _itemsCollection = _dbContext._database.GetCollection<IInventoryItem>("InventoryItem");
    }

    async public Task<IInventoryItem> CreateOne(IInventoryItem newDoc) {
      await _itemsCollection.InsertOneAsync(newDoc);
      return newDoc;
    }

    async public Task<IList<IInventoryItem>> GetAllAsync() {
      return await _itemsCollection.Find(_ => true).ToListAsync();
    }

    async public Task<IInventoryItem> GetByIdAsync(ObjectId id) {
      return await _itemsCollection.FindAsync(doc => doc.Id == id).Result.FirstAsync();
    }

    async public Task SetByIdAsync(IInventoryItem newDoc, ObjectId id) {
      await _itemsCollection.ReplaceOneAsync(doc => doc.Id == id, newDoc);
    }
  }
}
