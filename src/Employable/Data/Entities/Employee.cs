using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employable.Data.Entities
{
  public class Employee
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmployeeNumber { get; set; }
    public bool Active { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime ExitDate { get; set; }

    public ICollection<Address> Addresses { get; set; }

    public Department Department { get; set; }  

    public Employee Manager { get; set; }
    public ICollection<Employee> Reports { get; set; }

  }
}
