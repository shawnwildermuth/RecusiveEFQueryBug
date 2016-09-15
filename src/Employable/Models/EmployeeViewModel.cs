using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employable.Models
{
    public class EmployeeViewModel
    {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmployeeNumber { get; set; }
    public bool Active { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime ExitDate { get; set; }

    public ICollection<AddressViewModel> Addresses { get; set; }

    public ICollection<EmployeeViewModel> Reports { get; set; }
  }
}
