using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly SchoolDbContext context;

        public SubjectRepository(SchoolDbContext context)
        {
            this.context = context;
        }

        public int CreateSubject(Subjects subjects)
        {
            context.Subjects.Add(subjects);
            return context.SaveChanges();
        }

        public int DeleteSubject(int id)
        {
            var delSubject = GetSubject(id);
            if (delSubject != null)
            {
                context.Subjects.Remove(delSubject);
                return context.SaveChanges();
            }
            return -1;
        }

        public IEnumerable<Majors> GetMajors()
        {
            return context.Majors;
        }

        public Subjects GetSubject(int id)
        {
            return context.Subjects.FirstOrDefault(e => e.SubjectId == id);
        }

        public IEnumerable<ViewSubject> GetSubjects()
        {
            IEnumerable<ViewSubject> subjects = new List<ViewSubject>();
            subjects = (from s in context.Subjects
                        join m in context.Majors on s.MajorId equals m.MajorId
                       select (new ViewSubject()
                       {
                           SubjectId = s.SubjectId,
                           SubjectName = s.SubjectName,
                           MajorName = m.MajorName
                       }));
            return subjects;
        }

        public int UpdateSubject(UpdateSubject model)
        {
            var subject = GetSubject(model.SubjectId);
            if (subject == null)
            {
                return -1;
            }
            subject.SubjectName = model.SubjectName;
            subject.MajorId = model.MajorId;

            context.Update(subject);
            return context.SaveChanges();
        }
    }
}
