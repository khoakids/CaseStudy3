using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.ViewModels.Student
{
    public class AddStudentView : AddStudent
    {
        public AddStudentView()
        {
            Classes = new List<Classes>();
        }

        public IEnumerable<Classes> Classes { get; set; }
    }
}
