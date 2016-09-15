using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employable.Data.Entities;

namespace Employable.Data
{
  public class EmployableSeeder
  {
    private EmployableContext _ctx;

    public EmployableSeeder(EmployableContext ctx)
    {
      _ctx = ctx;
    }

    public void Seed()
    {
      if (!_ctx.Employees.Any())
      {
        var depts = new List<Department>()
        {
          new Department()
          {
            Name = "Development"
          },
          new Department()
          {
            Name = "Product Management"
          },
        };

        var employees = new List<Employee>()
        {
          new Employee()
          {
            FirstName = "Shawn",
            LastName = "Wildermuth",
            Active = true,
            ExitDate = DateTime.Today,
            HireDate = DateTime.Today,
            Department = depts[0],
            Addresses = new List<Address>()
            {
              new Address()
              {
                AddressLine1 = "123 Main Street",
                CityTown = "Atlanta",
                StateProvince = "GA",
                PostalCode = "12345",
                Country = "USA"
              }
            }, 
            Reports = new List<Employee>()
            {
              new Employee()
              {
                FirstName = "John",
                LastName = "Smith",
                Active = true,
                ExitDate = DateTime.Today,
                HireDate = DateTime.Today,
                Department = depts[0],
                Addresses = new List<Address>()
                {
                  new Address()
                  {
                    AddressLine1 = "123 Main Street",
                    CityTown = "Atlanta",
                    StateProvince = "GA",
                    PostalCode = "12345",
                    Country = "USA"
                  }
                },
                Reports = new List<Employee>()
                {
                  new Employee()
                  {
                    FirstName = "Jake",
                    LastName = "Forest",
                    Active = true,
                    ExitDate = DateTime.Today,
                    HireDate = DateTime.Today,
                    Department = depts[0],
                    Addresses = new List<Address>()
                    {
                      new Address()
                      {
                        AddressLine1 = "123 Main Street",
                        CityTown = "Atlanta",
                        StateProvince = "GA",
                        PostalCode = "12345",
                        Country = "USA"
                      }
                    }
                  }
                }
              }
            }
          },
          new Employee()
          {
            FirstName = "Resa",
            LastName = "Wildermuth",
            Active = true,
            ExitDate = DateTime.Today,
            HireDate = DateTime.Today,
            Department = depts[1],
            Addresses = new List<Address>()
            {
              new Address()
              {
                AddressLine1 = "123 Main Street",
                CityTown = "Atlanta",
                StateProvince = "GA",
                PostalCode = "12345",
                Country = "USA"
              }
            }
          }

        };

        _ctx.AddRange(depts);
        _ctx.Employees.AddRange(employees);

        _ctx.SaveChanges();
      }
    }
  }
}
