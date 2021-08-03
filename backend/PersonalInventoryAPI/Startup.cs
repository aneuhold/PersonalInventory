using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PersonalInventoryAPI.Contexts;
using PersonalInventoryAPI.Models;
using PersonalInventoryAPI.Models.Interfaces;
using PersonalInventoryAPI.Repositories;
using PersonalInventoryAPI.Repositories.Interfaces;

namespace PersonalInventoryAPI {
  public class Startup {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      AddDependencies(services);
      services.AddControllers()
        .AddNewtonsoftJson(options => options.UseMemberCasing()); ;
      services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "PersonalInventoryAPI", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonalInventoryAPI v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }

    private void AddDependencies(IServiceCollection services) {
      services.AddSingleton<MongoDbContext>()
        .AddSingleton<IInventoryItemRepository, InventoryItemRepository>()
        .AddTransient<IInventoryItem, InventoryItem>();

    }
  }
}
