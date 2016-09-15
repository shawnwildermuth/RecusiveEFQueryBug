using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Employable.Data;
using Employable.Data.Entities;
using Employable.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Employable
{
  public class Startup
  {
    private IConfigurationRoot _configuration;

    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
      _configuration = builder.Build();
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton(_configuration);

      services.AddTransient<EmployableSeeder>();

      services.AddDbContext<EmployableContext>(ServiceLifetime.Scoped);

      Mapper.Initialize(cfg =>
      {
        cfg.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        cfg.CreateMap<Department, DepartmentViewModel>().ReverseMap();
        cfg.CreateMap<Address, AddressViewModel>().ReverseMap();
      });

      services.AddSingleton(Mapper.Engine);

      // Add framework services.
      services.AddMvc()
        .AddJsonOptions(opt =>
        {
          opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, EmployableSeeder seeder, IMappingEngine mapper)
    {
      loggerFactory.AddConsole(_configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();

      seeder.Seed();
    }
  }
}
