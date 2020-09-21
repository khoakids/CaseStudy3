using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repository
{
    public interface ISubjectRepository
    {
        int CreateSubject(Subjects subjects);
        IEnumerable<ViewSubject> GetSubjects();
        Subjects GetSubject(int id);
        int UpdateSubject(UpdateSubject model);
        int DeleteSubject(int id);
        IEnumerable<Majors> GetMajors();
    }
}
