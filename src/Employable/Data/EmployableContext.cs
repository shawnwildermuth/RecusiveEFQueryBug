using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employable.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Employable.Data
{
  public class EmployableContext : DbContext
  {
    private IConfigurationRoot _config;

    public EmployableContext(DbContextOptions options, IConfigurationRoot config) : base(options)
    {
      _config = config;
      this.Database.EnsureCreated();
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);

      optionsBuilder.UseSqlServer(_config["Data:ConnectionString"]);
    }
  }
}
