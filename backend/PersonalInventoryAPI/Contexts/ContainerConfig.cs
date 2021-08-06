using Autofac;
using PersonalInventoryAPI.Models;
using PersonalInventoryAPI.Models.Interfaces;

namespace PersonalInventoryAPI.Contexts {
  public class ContainerConfig {
    public static IContainer Configure() {
      var builder = new ContainerBuilder();
      builder.RegisterType<InventoryItem>().As<IInventoryItem>();
      return builder.Build();
    }
  }
}
