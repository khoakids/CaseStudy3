using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.ViewModels.Class
{
    public class AddClass
    {
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Tên lớp học")]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Tên khoa")]
        public int MajorId { get; set; }
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Tên khóa học")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Tên môn học")]
        public int SubjectId { get; set; }
    }
}
