using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollageOrganization1.Windows.DAL;
using CollageOrganization1.Windows.Helpers;
using CollageOrganization1.Windows.Models;

namespace CollageOrganization1.Windows.BLL
{
    public class StudentBLL
    {
        private static CollegeOrganization1DBContext db = new CollegeOrganization1DBContext();

        public static Paged<Models.Student> Search(int pageIndex = 1, int pageSize = 1, string sortBy = "first name", string sortOrder = "asc", string keyword = "")
        {
            IQueryable<Student> allStudents = (IQueryable<Student>)db.Students;
            Paged<Models.Student> Students = new Paged<Student>();


            if (!string.IsNullOrEmpty(keyword))
            {
                allStudents = allStudents.Where(e => e.FirstName.Contains(keyword) || e.LastName.Contains(keyword));
            }

            var queryCount = allStudents.Count();
            var skip = pageSize * (pageIndex - 1);

            long pageCount = (long)Math.Ceiling((decimal)(queryCount / pageSize));

            if (sortBy.ToLower() == "lastname" && sortOrder.ToLower() == "asc")
            {
                Students.Items = allStudents.OrderBy(e => e.LastName).Skip(skip).Take(pageSize).ToList();
            }
            else if (sortBy.ToLower() == "lastname" && sortOrder.ToLower() == "desc")
            {
                Students.Items = allStudents.OrderByDescending(e => e.LastName).Skip(skip).Take(pageSize).ToList();
            }
            else if (sortBy.ToLower() == "salary" && sortOrder.ToLower() == "asc")
            {
                Students.Items = allStudents.OrderBy(e => e.DepartmentName).Skip(skip).Take(pageSize).ToList();
            }
            else
            {
                Students.Items = allStudents.OrderByDescending(e => e.DepartmentName).Skip(skip).Take(pageSize).ToList();
            }

            Students.PageCount = pageCount;
            Students.QueryCount = queryCount;
            Students.PageIndex = pageIndex;
            Students.PageSize = pageSize;


            return Students;
        }
        public static Operation Add(Student student)
        {
            try
            {
                student.IsActive = true;
                db.Students.Add(student);
                db.SaveChanges();

                return new Operation()
                {
                    Code = "200",
                    Message = "Ok",
                    ReferenceId = student.Id
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
        public static Operation Update(Student newRecord)
        {
            try
            {
                Student oldRecord = db.Students.FirstOrDefault(e => e.Id == newRecord.Id);

                if (oldRecord != null)
                {

                    oldRecord.FirstName = newRecord.FirstName;
                    oldRecord.LastName = newRecord.LastName;
                    oldRecord.EmailAddress = newRecord.EmailAddress;
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
