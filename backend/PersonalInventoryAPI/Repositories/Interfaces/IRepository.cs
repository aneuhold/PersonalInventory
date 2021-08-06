using MongoDB.Bson;
using PersonalInventoryAPI.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalInventoryAPI.Repositories.Interfaces {
  public interface IRepository<T> where T : IDocumentBase {
    public Task<IList<T>> GetAllAsync();
    public Task<long> DeleteAllAsync();
    public Task<T> CreateOne(T newDoc);
    public Task<T> GetByIdAsync(ObjectId id);
    public Task SetByIdAsync(T newDoc, ObjectId id);
  }
}
