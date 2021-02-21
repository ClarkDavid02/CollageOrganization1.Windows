using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollageOrganization1.Windows.DAL;
using CollageOrganization1.Windows.Helpers;
using CollageOrganization1.Windows.Models;
using CollageOrganization1.Windows.Models.Enums;


namespace CollageOrganization1.Windows.BLL
{
    public class EmployeeBLL
    {
        private static CollegeOrganization1DBContext db = new CollegeOrganization1DBContext();

        public static Paged<Models.Employee> Search(int pageIndex = 1, int pageSize = 1, string sortBy = "lastname", string sortOrder = "asc", string assignment = "", string status = "", string keyword = "")
        {
            IQueryable<Employee> allEmployees = (IQueryable<Employee>)db.Employees;
            Paged<Models.Employee> Employees = new Paged<Employee>();


            if (!string.IsNullOrEmpty(keyword))
            {
                allEmployees = allEmployees.Where(e => e.FirstName.Contains(keyword) || e.LastName.Contains(keyword));
            }

            var queryCount = allEmployees.Count();
            var skip = pageSize * (pageIndex - 1);

            long pageCount = (long)Math.Ceiling((decimal)(queryCount / pageSize));

            if (sortBy.ToLower() == "lastname" && sortOrder.ToLower() == "asc")
            {
                Employees.Items = allEmployees.OrderBy(e => e.LastName).Skip(skip).Take(pageSize).ToList();
            }
            else if (sortBy.ToLower() == "lastname" && sortOrder.ToLower() == "desc")
            {
                Employees.Items = allEmployees.OrderByDescending(e => e.LastName).Skip(skip).Take(pageSize).ToList();
            }
            else if (sortBy.ToLower() == "salary" && sortOrder.ToLower() == "asc")
            {
                Employees.Items = allEmployees.OrderBy(e => e.DepartmentName).Skip(skip).Take(pageSize).ToList();
            }
            else
            {
                Employees.Items = allEmployees.OrderByDescending(e => e.DepartmentName).Skip(skip).Take(pageSize).ToList();
            }

            Employees.PageCount = pageCount;
            Employees.QueryCount = queryCount;
            Employees.PageIndex = pageIndex;
            Employees.PageSize = pageSize;


            return Employees;
        }
        public static Operation Add(Employee employee)
        {
            try
            {
                employee.IsActive = true;
                db.Employees.Add(employee);
                db.SaveChanges();

                return new Operation()
                {
                    Code = "200",
                    Message = "Ok",
                    ReferenceId = employee.Id
                };
            }
            catch (Exception e)
            {
                return new Operation()
                {
                    Code = "500",
                    Message = e.Message
                };
            }
        }

        public static Employee GetById(Guid? id)
        {
            return db.Employees.FirstOrDefault(e => e.Id == id);
        }

        public static Operation Login(string emailAddress = "", string password = "")
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                return new Operation()
                {
                    Code = "500",
                    Message = "Invalid Login"
                };
            }

            if (string.IsNullOrEmpty(password))
            {
                return new Operation()
                {
                    Code = "500",
                    Message = "Invalid Login"
                };
            }

            try
            {
                Employee user = db.Employees.FirstOrDefault(e => e.EmailAddress.ToLower() == emailAddress.ToLower());

                if (user == null)
                {
                    return new Operation()
                    {
                        Code = "500",
                        Message = "Invalid Login"
                    };
                }

                if (password == user.Password)
                {
                    return new Operation()
                    {
                        Code = "200",
                        Message = "Successful Login",
                        ReferenceId = user.Id
                    };
                }

                return new Operation()
                {
                    Code = "500",
                    Message = "Invalid Login"
                };
            }
            catch (Exception e)
            {
                return new Operation()
                {
                    Code = "500",
                    Message = e.Message
                };
            }
        }
        public static Operation Update(Employee newRecord)
        {
            try
            {
                Employee oldRecord = db.Employees.FirstOrDefault(e => e.Id == newRecord.Id);

                if (oldRecord != null)
                {
                    oldRecord.Assignment = newRecord.Assignment;
                    oldRecord.EmailAddress = newRecord.EmailAddress;
                    oldRecord.FirstName = newRecord.FirstName;
                    oldRecord.LastName = newRecord.LastName;
                    oldRecord.Gender = newRecord.Gender;
                    oldRecord.DepartmentName = newRecord.DepartmentName;
                    oldRecord.IsActive = true;

                    db.SaveChanges();

                    return new Operation()
                    {
                        Code = "200",
                        Message = "OK"
                    };
                }


                return new Operation()
                {
                    Code = "500",
                    Message = "Not found"
                };
            }
            catch (Exception e)
            {
                return new Operation()
                {
                    Code = "500",
                    Message = e.Message
                };
            }
        }
    }
}
