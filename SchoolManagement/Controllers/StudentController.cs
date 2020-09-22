using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Student;
using SchoolManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
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

        private AddStudentView Collect()
        {
            var model = new AddStudentView();
            model.Classes = studentRepository.GetClasses();
            return model;
        }
        [HttpPost]
        public IActionResult Create(AddStudent model)
        {
            if (ModelState.IsValid)
            {
                var students = new Students()
                {
                    StudentName = model.StudentName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    BirthDay = model.Birthday,
                    ClassId = model.ClassId
                };
                var studentId = studentRepository.CreateStudent(students);
                if (studentId > 0)
                {
                    return RedirectToAction("Index", "Student");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var classStudent = new AddStudent();
            return View(classStudent);
        }
        public IActionResult Index()
        {
            var students = new List<ViewStudent>();
            students = studentRepository.GetStudents().ToList();
            return View(students);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var students = studentRepository.GetStudent(id);
            var editStudent = new UpdateStudent();
            if (students != null)
            {
                editStudent.StudentId = students.StudentId;
                editStudent.StudentName = students.StudentName;
                editStudent.Birthday = students.BirthDay;
                editStudent.ClassId = students.ClassId;
                editStudent.PhoneNumber = students.PhoneNumber;
                editStudent.Email = students.Email;
                editStudent.Classes = studentRepository.GetClasses();
            }
            return View(editStudent);
        }

        [HttpPost]
        public IActionResult Edit(UpdateStudent model)
        {
            if (ModelState.IsValid)
            {
                if (studentRepository.UpdateStudent(model) > 0)
                {
                    return RedirectToAction("Index", "Student");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var classEdit = new UpdateStudent();
            return View(classEdit);
        }

        [HttpGet]
        [Route("/Student/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var deleteStudent = studentRepository.DeleteStudent(id);
            return Json(new { deleteStudent });
        }
    }
}
