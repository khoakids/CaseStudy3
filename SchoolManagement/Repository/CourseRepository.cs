using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext context;

        public CourseRepository(SchoolDbContext context)
        {
            this.context = context;
        }

        public int CreateCourse(Courses courses)
        {
            context.Courses.Add(courses);
            return context.SaveChanges();
        }

        public int DeleteCourse(int id)
        {
            var delCourse = GetCourse(id);
            if (delCourse != null)
            {
                context.Courses.Remove(delCourse);
                return context.SaveChanges();
            }
            return -1;
        }

        public Courses GetCourse(int id)
        {
            return context.Courses.FirstOrDefault(e => e.CourseId == id);
        }

        public IEnumerable<ViewCourse> GetCourses()
        {
            IEnumerable<ViewCourse> courses = new List<ViewCourse>();
            courses = (from c in context.Courses
                      select (new ViewCourse()
                      {
                          CourseId = c.CourseId,
                          CourseName = c.CourseName,
                          StartDay = c.StartDay,
                          FinishDay = c.FinishDay
                      }));
            return courses;
        }

        public int UpdateCourse(UpdateCourse model)
        {
            var course = GetCourse(model.CourseId);
            if (course == null)
            {
                return -1;
            }
            course.CourseId = model.CourseId;
            course.CourseName = model.CourseName;
            course.StartDay = model.StartDay;
            course.FinishDay = model.FinishDay;

            context.Update(course);
            return context.SaveChanges();
        }
    }
}
