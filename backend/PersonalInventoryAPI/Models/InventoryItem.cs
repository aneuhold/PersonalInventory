using System;

namespace PersonalInventoryAPI.Models {
  public class InventoryItem : IInventoryItem {
    public Guid Id { get; }
    public string Name { get; set; }
    public string Location { get; set; }

    public InventoryItem(string name, string location) : this() {
      Name = name;
      Location = location;
    }

    public InventoryItem(string name) : this() {
      Name = name;
    }

    public InventoryItem() {
      Id = new Guid();
    }
  }
}
