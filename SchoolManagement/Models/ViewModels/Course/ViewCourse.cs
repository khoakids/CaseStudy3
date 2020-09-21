using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.ViewModels.Course
{
    public class ViewCourse
    {
        public int CourseId { get; set; }
        public DateTime? StartDay { get; set; }
        public DateTime? FinishDay { get; set; }
    }
}
