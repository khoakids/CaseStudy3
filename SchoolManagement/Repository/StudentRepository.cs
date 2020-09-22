using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SchoolManagement.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext context;

        public StudentRepository(SchoolDbContext context)
        {
            this.context = context;
        }

        public int CreateStudent(Students students)
        {
            context.Students.Add(students);
            return context.SaveChanges();
        }

        public int DeleteStudent(int id)
        {
            var delStudent = GetStudent(id);
            if (delStudent != null)
            {
                context.Students.Remove(delStudent);
                return context.SaveChanges();
            }
            return -1;
        }

        public IEnumerable<Classes> GetClasses()
        {
            return context.Classes;
        }

        public Students GetStudent(int id)
        {
            return context.Students.FirstOrDefault(e => e.StudentId == id);
        }

        public IEnumerable<ViewStudent> GetStudents()
        {
            IEnumerable<ViewStudent> students = new List<ViewStudent>();
            students = (from s in context.Students
                       join c in context.Classes on s.ClassId equals c.ClassId
                       select (new ViewStudent()
                       {
                           StudentId = s.StudentId,
                           StudentName = s.StudentName,
                           Birthday = s.BirthDay,
                           PhoneNumber = s.PhoneNumber,
                           Email = s.Email,
                           ClassName = c.ClassName
                       }));
            return students;
        }

        public int UpdateStudent(UpdateStudent model)
        {
            var students = GetStudent(model.StudentId);
            if (students == null)
            {
                return -1;
            }
            students.StudentName = model.StudentName;
            students.BirthDay = model.Birthday;
            students.Email = model.Email;
            students.ClassId = model.ClassId;
            students.PhoneNumber = model.PhoneNumber;

            context.Update(students);
            return context.SaveChanges();
        }
    }
}
