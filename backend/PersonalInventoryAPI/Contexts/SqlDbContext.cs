using Microsoft.EntityFrameworkCore;
using PersonalInventoryAPI.Models;
using System;

namespace PersonalInventoryAPI.Contexts {
  public class SqlDbContext : DbContext {
    public DbSet<InventoryItem> InventoryItems { get; set; }

    public string DbPath { get; private set; }
    public SqlDbContext() {
      var folder = Environment.SpecialFolder.LocalApplicationData;
      var path = Environment.GetFolderPath(folder);
      DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}personalInventory.db";
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

  }
}
