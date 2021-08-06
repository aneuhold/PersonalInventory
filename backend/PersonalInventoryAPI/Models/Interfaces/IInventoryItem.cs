namespace PersonalInventoryAPI.Models.Interfaces {
  public abstract class IInventoryItem : IDocumentBase {
    public string Name { get; set; }
    public string Location { get; set; }
  }
}
