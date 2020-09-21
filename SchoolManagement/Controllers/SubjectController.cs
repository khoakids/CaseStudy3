using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Subject;
using SchoolManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository subjectRepository;
        private SchoolDbContext _context;

        public SubjectController(ISubjectRepository subjectRepository, SchoolDbContext context)
        {
            this.subjectRepository = subjectRepository;
            this._context = context;
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

        private AddSubjectView Collect()
        {
            var model = new AddSubjectView();
            model.Major = subjectRepository.GetMajors();
            return model;
        }
        [HttpPost]
        public IActionResult Create(AddSubject model)
        {
            if (ModelState.IsValid)
            {
                var subject = new Subjects()
                {
                    SubjectName = model.SubjectName,
                    MajorId = model.MajorId
                };
                var subjectId = subjectRepository.CreateSubject(subject);
                if (subjectId > 0)
                {
                    return RedirectToAction("Index", "Subject");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var subjectView = new AddSubject();
            return View(subjectView);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var subject = subjectRepository.GetSubject(id);
            var editSubject = new UpdateSubject();
            if (subject != null)
            {
                editSubject.SubjectId = subject.SubjectId;
                editSubject.SubjectName = subject.SubjectName;
                editSubject.MajorId = subject.MajorId;
                editSubject.Major = subjectRepository.GetMajors();
            }
            return View(editSubject);
        }

        [HttpPost]
        public IActionResult Edit(UpdateSubject model)
        {
            if (ModelState.IsValid)
            {
                if (subjectRepository.UpdateSubject(model) > 0)
                {
                    return RedirectToAction("Index", "Subject");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var subjectEdit = new UpdateSubject();
            return View(subjectEdit);
        }

        [HttpGet]
        [Route("/Subject/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var deleteSubject = subjectRepository.DeleteSubject(id);
            return Json(new { deleteSubject });
        }

        public IActionResult Index()
        {
            var subjects = new List<ViewSubject>();
            subjects = subjectRepository.GetSubjects().ToList();
            return View(subjects);
        }
    }
}
