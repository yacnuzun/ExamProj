using ExamProj.Models;
using ExamProj.Models.DTOs;
using ExamProj.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ExamProj.Controllers
{
    public class ExamController : Controller
    {
        Context _context=new Context();
        public IActionResult Index()
        {
            List<Exam> exam = _context.Exams.ToList();
            return View(exam);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Exam exam)
        {
            _context.Exams.Add(exam);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var exam = _context.Exams.SingleOrDefault(e=>e.ExampId==id);
            return View("Update", exam);
        }
        [HttpPost]
        public IActionResult Updated(Exam exam)
        {
            _context.Exams.Update(exam);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var exam = _context.Exams.FirstOrDefault(e => e.ExampId == id);
            _context.Exams.Remove(exam);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var examQuestionDto = (from q in _context.Questions.Where(q=>q.ExampId==id)
                                  join e in _context.Exams
                                  on q.ExampId equals e.ExampId
                                  join ca in _context.Categories
                                  on q.CategoryId equals ca.CategoryId
                                  join qt in _context.QuestionTypes
                                  on q.QuestionTypeId equals qt.QuestionTypeId
                                  select new ExamQuestionDTO()
                                  {
                                      QuestionId=q.QuestionId,
                                      QuestionName = q.QuestionName,
                                      QuestionAnswer = q.QuestionAnswer,
                                      QuestionTypeName = qt.QuestionTypeName,
                                      CategoryName = ca.CategoryName
                                  }).ToList();
            var examName=_context.Exams.Where(q=>q.ExampId==id).Select(qu=>qu.ExamName).FirstOrDefault();
            ViewBag.ExamName = examName;
            return View(examQuestionDto);
        }
    }
}
