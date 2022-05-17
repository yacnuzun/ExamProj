﻿using ExamProj.Models;
using ExamProj.Models.DTOs;
using ExamProj.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ExamProj.Controllers
{
    public class QuestionController : Controller
    {
        Context _context = new Context();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(int id)
        {
            List<Exam> exid = _context.Exams.Where(e => e.ExampId == id).ToList();
            return View(exid);
        }
        public IActionResult DescriptAdd(int id)
        {

            ViewBag.categories = _context.Categories.ToList();
            ViewBag.exid = _context.Exams.Where(e => e.ExampId == id).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult DescriptAdded(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
            return Redirect("~/Exam/Index");
        }
        public IActionResult ChoiseAdd(int id)
        {
            ViewBag.categories = _context.Categories.ToList();
            ViewBag.exid = _context.Exams.Where(e => e.ExampId == id).ToList();
            return View();
        }
        public IActionResult ChoiseAdded(ChoiseQuestionDto choiseQuestion)
        {
        //    _context.Questions.Add(question);
        //    _context.Choices.Add(choice);
            _context.SaveChanges();
            return RedirectToAction("ChoisesAdded");
        }
        public IActionResult ChoisesAdded(Choice choice)
        {
            return Redirect("~/Exam/Index");
        }
        public IActionResult Detail(int id)
        {
            var examQuestionDto = (from q in _context.Questions.Where(q => q.ExampId == id)
                                   join e in _context.Exams
                                   on q.ExampId equals e.ExampId
                                   join ca in _context.Categories
                                   on q.CategoryId equals ca.CategoryId
                                   join qt in _context.QuestionTypes
                                   on q.QuestionTypeId equals qt.QuestionTypeId
                                   select new ExamQuestionDTO()
                                   {
                                       ExamId = e.ExampId,
                                       QuestionId = q.QuestionId,
                                       QuestionName = q.QuestionName,
                                       QuestionAnswer = q.QuestionAnswer,
                                       QuestionTypeName = qt.QuestionTypeName,
                                       CategoryName = ca.CategoryName
                                   }).ToList();
            ViewBag.exams = _context.Exams.Where(q => q.ExampId == id).ToList();

            return View(examQuestionDto);

        }
       
        public IActionResult Delete(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.QuestionId== id);
            _context.Questions.Remove(question);
            _context.SaveChanges();
            return Redirect("~/Exam/Index");
        }
    }
}
