using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repository
{
    public interface ICourseRepository
    {
        int CreateCourse(Courses courses);
        IEnumerable<ViewCourse> GetCourses();
        Courses GetCourse(int id);
        int UpdateCourse(UpdateCourse model);
        int DeleteCourse(int id);
    }
}
