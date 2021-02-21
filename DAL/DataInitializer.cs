using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CollageOrganization1.Windows.DAL
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseAlways<CollegeOrganization1DBContext>
    {
        protected override void Seed(CollegeOrganization1DBContext context)
        {
            context.Employees.Add(new Models.Employee()
            {
                Id = Guid.Parse("56bac4c3-ef14-4f17-905d-5fb554063561"),
                FirstName = "Jace",
                LastName = "Beleren",
                Assignment = Models.Enums.Assignment.Office,
                EmailAddress = "jbeleren@gmail.com",
                DepartmentName = "BSIS",
                ContactNumber = "09876675843",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });
            context.Employees.Add(new Models.Employee()
            {
                Id = Guid.Parse("98bac4c3-ef14-4f17-905d-5fb559103475"),
                FirstName = "Bvell",
                LastName = "Genova",
                Assignment = Models.Enums.Assignment.Field,
                EmailAddress = "bvgen@gmail.com",
                DepartmentName = "BSBA",
                ContactNumber = "09675889421",
                Gender = Models.Enums.Gender.Female,
                IsActive = true
            });

            context.Employees.Add(new Models.Employee()
            {
                Id = Guid.Parse("98bac4c3-ef14-4f17-905d-5fb5533452130"),
                FirstName = "Melo",
                LastName = "Glovania",
                Assignment = Models.Enums.Assignment.Field,
                EmailAddress = "megalonia@gmail.com",
                DepartmentName = "BSBM",
                ContactNumber = "096573245571",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Employees.Add(new Models.Employee()
            {
                Id = Guid.Parse("98bac4c3-ef14-4f17-905d-5fb559103475"),
                FirstName = "Leovan",
                LastName = "Kemninsh",
                Assignment = Models.Enums.Assignment.Office,
                EmailAddress = "kenkenv@gmail.com",
                DepartmentName = "BS Criminology",
                ContactNumber = "09235564728",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Employees.Add(new Models.Employee()
            {
                Id = Guid.Parse("98bac4c3-ef14-4f17-905d-5fb5533452130"),
                FirstName = "Nickie",
                LastName = "Pendocian",
                Assignment = Models.Enums.Assignment.Field,
                EmailAddress = "megalonia@gmail.com",
                DepartmentName = "BSCA",
                ContactNumber = "096335678823",
                Gender = Models.Enums.Gender.Female,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("47gca6b7-ef01-4f37-575d-5fb75663840088"),
                FirstName = "Kevin",
                LastName = "Neoliton",
                EmailAddress = "Kevliton@gmail.com",
                ContactNumber = "09345537021",
                DepartmentName = "BSIS",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("97gca6b7-ef01-4f37-575d-5fb1147634997"),
                FirstName = "Trence",
                LastName = "Schlatt",
                EmailAddress = "Trencett@gmail.com",
                ContactNumber = "09345537021",
                DepartmentName = "BSIS",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("78gca6b7-ef01-4f37-575d-5fb5339801256"),
                FirstName = "Penny",
                LastName = "Jecina",
                EmailAddress = "Jpenn@gmail.com",
                ContactNumber = "09345537021",
                DepartmentName = "BSIS",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("64gca6b7-ef01-4f37-575d-5fb4459800562"),
                FirstName = "Dairus",
                LastName = "Quinzel",
                EmailAddress = "Qairusinzel@gmail.com",
                ContactNumber = "09345537021",
                DepartmentName = "BS Criminology",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("09gca6b7-ef01-4f37-575d-5fb7674559081"),
                FirstName = "Jemica",
                LastName = "Klevious",
                EmailAddress = "Jekvleca@gmail.com",
                ContactNumber = "09345537021",
                DepartmentName = "BS Criminology",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("09gca6b7-ef01-4f37-575d-5fb8586643451"),
                FirstName = "Lannie",
                LastName = "Spectro",
                EmailAddress = "spectroLane@gmail.com",
                ContactNumber = "09349807765",
                DepartmentName = "BS Criminology",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("09gca6b7-ef01-4f37-575d-5fb7758439411"),
                FirstName = "Ferddie",
                LastName = "Krilium",
                EmailAddress = "Frellium@gmail.com",
                ContactNumber = "097266841345",
                DepartmentName = "BSCA",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("09gca6b7-ef01-4f37-575d-5fb2745664879"),
                FirstName = "Haochi",
                LastName = "Anarimity",
                EmailAddress = "Haramichi@gmail.com",
                ContactNumber = "09114657883",
                DepartmentName = "BSCA",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("09gca6b7-ef01-4f37-575d-5fb8586643451"),
                FirstName = "Verrie",
                LastName = "Chiuson",
                EmailAddress = "CHVerrie@gmail.com",
                ContactNumber = "09436769043",
                DepartmentName = "BSCA",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("09gca6b7-ef01-4f37-575d-5fb7688345952"),
                FirstName = "Sweish",
                LastName = "Qwanty",
                EmailAddress = "Sqaneish@gmail.com",
                ContactNumber = "09435582219",
                DepartmentName = "BSBA",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("09gca6b7-ef01-4f37-575d-5fb5568723443"),
                FirstName = "Yvie",
                LastName = "Mirage",
                EmailAddress = "mimiyvira@gmail.com",
                ContactNumber = "09164457689",
                DepartmentName = "BSBA",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("09gca6b7-ef01-4f37-575d-5fb8823461557"),
                FirstName = "Gazel",
                LastName = "Dalimus",
                EmailAddress = "dalgizel@gmail.com",
                ContactNumber = "09498676550",
                DepartmentName = "BSBA",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("09gca6b7-ef01-4f37-575d-5fb3436672645"),
                FirstName = "Devin",
                LastName = "Jhoeh",
                EmailAddress = "djoeh@gmail.com",
                ContactNumber = "09266745563",
                DepartmentName = "BSBM",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("09gca6b7-ef01-4f37-575d-5fb1988567543"),
                FirstName = "Vlad",
                LastName = "Freght",
                EmailAddress = "vladie@gmail.com",
                ContactNumber = "09376884367",
                DepartmentName = "BSBM",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Students.Add(new Models.Student()
            {
                Id = Guid.Parse("09gca6b7-ef01-4f37-575d-5fb2436655782"),
                FirstName = "Diana",
                LastName = "Blossom",
                EmailAddress = "diablos@gmail.com",
                ContactNumber = "09668827943",
                DepartmentName = "BSBM",
                Gender = Models.Enums.Gender.Male,
                IsActive = true
            });

            context.Employees.Add(new Models.Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = "Jace",
                LastName = "Beleren",
                EmailAddress = "jbeleren@gmail.com",
                Password = "jebeleren",
                ContactNumber = "09876675843"
            }); 

            context.SaveChanges();
        }

    }
}
