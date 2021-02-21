using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using CollageOrganization1.Windows.Models;

namespace CollageOrganization1.Windows.DAL
{
    public class CollegeOrganization1DBContext : DbContext
    {
        public CollegeOrganization1DBContext() : base("myConnectionString")
        {
            Database.SetInitializer(new CollageOrganization1.Windows.DAL.DataInitializer());
        }
        public DbSet<Models.Department> DepartmentNames { get; set; }
        public DbSet<Models.Employee> Employees { get; set; }
        public DbSet<Models.Student> Students { get; set; }
    }
}
