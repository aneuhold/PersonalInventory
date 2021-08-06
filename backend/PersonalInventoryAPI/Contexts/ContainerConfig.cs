using Autofac;
using PersonalInventoryAPI.Models;
using PersonalInventoryAPI.Models.Interfaces;

namespace PersonalInventoryAPI.Contexts {

  /// <summary>
  /// This currently isn't used, but will be when Autofac is used.
  /// </summary>
  public class ContainerConfig {
    public static IContainer Configure() {
      var builder = new ContainerBuilder();
      builder.RegisterType<InventoryItem>().As<IInventoryItem>();
      return builder.Build();
    }
  }
}
