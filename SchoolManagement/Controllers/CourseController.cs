using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Course;
using SchoolManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> logger;
        private readonly ICourseRepository courseRepository;

        public CourseController(ILogger<CourseController> logger, ICourseRepository courseRepository)
        {
            this.logger = logger;
            this.courseRepository = courseRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AddCourse model)
        {
            if (ModelState.IsValid)
            {
                var course = new Courses()
                {
                    CourseName = model.CourseName,
                    StartDay = model.StartDay,
                    FinishDay = model.FinishDay
                };
                var courseId = courseRepository.CreateCourse(course);
                if (courseId > 0)
                {
                    return RedirectToAction("Index", "Course");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var courseView = new AddCourse();
            return View(courseView);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = courseRepository.GetCourse(id);
            var editCourse = new UpdateCourse();
            if (course != null)
            {
                editCourse.CourseId = course.CourseId;
                editCourse.CourseName = course.CourseName;
                editCourse.StartDay = course.StartDay;
                editCourse.FinishDay = course.FinishDay;
            }
            return View(editCourse);
        }

        [HttpPost]
        public IActionResult Edit(UpdateCourse model)
        {
            if (ModelState.IsValid)
            {
                if (courseRepository.UpdateCourse(model) > 0)
                {
                    return RedirectToAction("Index", "Course");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var courseEdit = new UpdateCourse();
            return View(courseEdit);
        }

        [HttpGet]
        [Route("/Course/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var deleteCourse = courseRepository.DeleteCourse(id);
            return Json(new { deleteCourse });
        }

        public IActionResult Index()
        {
            var courses = new List<ViewCourse>();
            courses = courseRepository.GetCourses().ToList();
            return View(courses);
        }
    }
}
