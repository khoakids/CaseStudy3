using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Class;
using SchoolManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassRepository classRepository;

        public ClassController(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            //var major = _context.Majors.ToList();
            //AddSubjectView addSubjectView = new AddSubjectView();
            //addSubjectView.Major = major;
            //return View(addSubjectView);
            return View(Collect());
        }

        private AddClassView Collect()
        {
            var model = new AddClassView();
            model.Majors = classRepository.GetMajors();
            model.Course = classRepository.GetCourses();
            model.Subject = classRepository.GetSubjects();
            return model;
        }
        [HttpPost]
        public IActionResult Create(AddClass model)
        {
            if (ModelState.IsValid)
            {
                var classes = new Classes()
                {
                    ClassName = model.ClassName,
                    MajorId = model.MajorId,
                    CourseId = model.CourseId,
                    SubjectId = model.SubjectId
                };
                var classId = classRepository.CreateClass(classes);
                if (classId > 0)
                {
                    return RedirectToAction("Index", "Class");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var classView = new AddClass();
            return View(classView);
        }
        public IActionResult Index()
        {
            var classes = new List<ViewClass>();
            classes = classRepository.GetClasses().ToList();
            return View(classes);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var classes = classRepository.GetClass(id);
            var editClass = new UpdateClass();
            if (classes != null)
            {
                editClass.ClassId = classes.ClassId;
                editClass.ClassName = classes.ClassName;
                editClass.MajorId = classes.MajorId;
                editClass.CourseId = classes.CourseId;
                editClass.SubjectId = classes.SubjectId;
                editClass.Majors = classRepository.GetMajors();
                editClass.Course = classRepository.GetCourses();
                editClass.Subject = classRepository.GetSubjects();
            }
            return View(editClass);
        }

        [HttpPost]
        public IActionResult Edit(UpdateClass model)
        {
            if (ModelState.IsValid)
            {
                if (classRepository.UpdateClass(model) > 0)
                {
                    return RedirectToAction("Index", "Class");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var classEdit = new UpdateClass();
            return View(classEdit);
        }

        [HttpGet]
        [Route("/Class/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var deleteClass = classRepository.DeleteClass(id);
            return Json(new { deleteClass });
        }

    }
}
