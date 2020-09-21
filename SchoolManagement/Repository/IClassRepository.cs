using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repository
{
    public interface IClassRepository
    {
        int CreateClass(Classes classes);
        IEnumerable<ViewClass> GetClasses();
        Classes GetClass(int id);
        int UpdateClass(UpdateClass model);
        int DeleteClass(int id);
        IEnumerable<Majors> GetMajors();
        IEnumerable<Courses> GetCourses();
        IEnumerable<Subjects> GetSubjects();
    }
}
