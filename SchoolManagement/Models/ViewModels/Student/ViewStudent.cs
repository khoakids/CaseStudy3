using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.ViewModels.Student
{
    public class ViewStudent
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime? Birthday { get; set; }
        public string ClassName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
