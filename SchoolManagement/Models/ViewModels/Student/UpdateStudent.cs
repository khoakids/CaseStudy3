using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.ViewModels.Student
{
    public class UpdateStudent : AddStudent
    {
        public UpdateStudent()
        {
            Classes = new List<Classes>();
        }
        public int StudentId { get; set; }
        public IEnumerable<Classes> Classes { get; set; }
    }
}
