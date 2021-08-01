using System;

namespace PersonalInventoryAPI.Models {
  interface IInventoryItem {
    public Guid Id { get; }
    public string Name { get; set; }
    public string Location { get; set; }

  }
}
