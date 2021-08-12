using Autofac;
using Autofac.Extensions.DependencyInjection;
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
using Serilog;

namespace PersonalInventoryAPI {
  public class Startup {
    public IConfiguration Configuration { get; }
    public ILifetimeScope AutofacContainer { get; private set; }

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {

      services.AddControllers()
        .AddNewtonsoftJson(options => options.UseMemberCasing()); ;
      services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "PersonalInventoryAPI", Version = "v1" });
      });
      services.AddOptions();
    }

    /// <summary>
    /// ConfigureContainer is where you can register things directly
    /// with Autofac. This runs after ConfigureServices so the things
    /// here will override registrations made in ConfigureServices.
    /// Don't build the container; that gets done for you by the factory.
    /// </summary>
    /// <param name="builder"></param>
    public void ConfigureContainer(ContainerBuilder builder) {
      builder.RegisterType<InventoryItem>().As<IInventoryItem>();
      builder.RegisterType<InventoryItemRepository>().As<IInventoryItemRepository>();
      builder.RegisterType<MongoDbContext>().AsSelf();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      AutofacContainer = app.ApplicationServices.GetAutofacRoot();

      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonalInventoryAPI v1"));
      }

      app.UseHttpsRedirection();

      app.UseSerilogRequestLogging();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}
