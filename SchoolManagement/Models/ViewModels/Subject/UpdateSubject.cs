using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.ViewModels.Subject
{
    public class UpdateSubject : AddSubject
    {
        public UpdateSubject()
        {
            Major = new List<Majors>();
        }
        public int SubjectId { get; set; }
        public IEnumerable<Majors> Major { get; set; }
    }
}
