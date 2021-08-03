using MongoDB.Bson;
using PersonalInventoryAPI.Models.Interfaces;

namespace PersonalInventoryAPI.Models {
  public class InventoryItem : IInventoryItem {

    public InventoryItem(string name, string location) : this() {
      Name = name;
      Location = location;
    }

    public InventoryItem(string name) : this() {
      Name = name;
    }

    public InventoryItem() {
      Id = ObjectId.GenerateNewId();
    }
  }
}
