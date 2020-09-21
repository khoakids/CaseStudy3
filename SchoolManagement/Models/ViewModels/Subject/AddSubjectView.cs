using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.ViewModels.Subject
{
    public class AddSubjectView : AddSubject
    {
        public AddSubjectView()
        {
            Major = new List<Majors>();
        }

        public IEnumerable<Majors> Major { get; set; }
    }
}
