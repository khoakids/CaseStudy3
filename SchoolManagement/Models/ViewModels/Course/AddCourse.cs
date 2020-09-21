using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.ViewModels.Course
{
    public class AddCourse
    {
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Ngày bắt đầu")]
        public DateTime? StartDay { get; set; }
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Ngày kết thúc")]
        public DateTime? FinishDay { get; set; }
    }
}
