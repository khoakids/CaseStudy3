using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repository
{
    public interface IStudentRepository
    {
        int CreateStudent(Students students);
        IEnumerable<ViewStudent> GetStudents();
        Students GetStudent(int id);
        int UpdateStudent(UpdateStudent model);
        int DeleteStudent(int id);
        IEnumerable<Classes> GetClasses();
    }
}
