using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.ViewModels.Class
{
    public class UpdateClass : AddClass
    {
        public UpdateClass()
        {
            Majors = new List<Majors>();
            Course = new List<Courses>();
            Subject = new List<Subjects>();
        }
        public int ClassId { get; set; }
        public IEnumerable<Majors> Majors { get; set; }
        public IEnumerable<Courses> Course { get; set; }
        public IEnumerable<Subjects> Subject { get; set; }
    }
}
