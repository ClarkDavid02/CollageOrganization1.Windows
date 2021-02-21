using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollageOrganization1.Windows.Models.Enums;

namespace CollageOrganization1.Windows.Models
{
    public class Employee
    {
       
            public Guid? Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailAddress { get; set; }
            public string DepartmentName { get; set; }
            public string ContactNumber { get; set; }
            public string Password { get; set; }
            public Assignment Assignment { get; set; }
            public Gender Gender { get; set; }
            public bool IsActive { get; set; }
        
    }
}
