using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly SchoolDbContext context;

        public ClassRepository(SchoolDbContext context)
        {
            this.context = context;
        }

        public int CreateClass(Classes classes)
        {
            context.Classes.Add(classes);
            return context.SaveChanges();
        }

        public int DeleteClass(int id)
        {
            var delClass = GetClass(id);
            if (delClass != null)
            {
                context.Classes.Remove(delClass);
                return context.SaveChanges();
            }
            return -1;
        }

        public Classes GetClass(int id)
        {
            return context.Classes.FirstOrDefault(e => e.ClassId == id);
        }

        public IEnumerable<ViewClass> GetClasses()
        {
            IEnumerable<ViewClass> classes = new List<ViewClass>();
            classes = (from cl in context.Classes
                       join co in context.Courses on cl.CourseId equals co.CourseId
                       join m in context.Majors on cl.MajorId equals m.MajorId
                       join s in context.Subjects on cl.SubjectId equals s.SubjectId
                       select (new ViewClass()
                       {
                           ClassId = cl.ClassId,
                           ClassName = cl.ClassName,
                           MajorName = m.MajorName,
                           SubjectName = s.SubjectName,
                           CourseId = co.CourseId
                       }));
            return classes;
        }

        public IEnumerable<Courses> GetCourses()
        {
            return context.Courses;
        }

        public IEnumerable<Majors> GetMajors()
        {
            return context.Majors;
        }

        public IEnumerable<Subjects> GetSubjects()
        {
            return context.Subjects;
        }

        public int UpdateClass(UpdateClass model)
        {
            var classes = GetClass(model.ClassId);
            if (classes == null)
            {
                return -1;
            }
            classes.ClassName = model.ClassName;
            classes.MajorId = model.MajorId;
            classes.CourseId = model.CourseId;
            classes.SubjectId = model.SubjectId;

            context.Update(classes);
            return context.SaveChanges();
        }
    }
}
