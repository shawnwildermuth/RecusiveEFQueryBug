using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employable.Models
{
  public class DepartmentViewModel
  {
    public string Name { get; set; }
    public ICollection<EmployeeViewModel> Employees { get; set; }
  }
}
