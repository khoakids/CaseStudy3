using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.ViewModels.Subject
{
    public class AddSubject
    {
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Tên khoa")]
        public int MajorId { get; set; }
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Tên môn học")]
        public string SubjectName { get; set; }
    }
}
