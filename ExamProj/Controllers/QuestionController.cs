using ExamProj.Models;
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
        public IActionResult Update(int id)
        {
            var secQuestion = (from q in _context.Questions.Where(q => q.QuestionId == id)
                               join c in _context.Categories
                               on q.CategoryId equals c.CategoryId
                               join qt in _context.QuestionTypes
                               on q.QuestionTypeId equals qt.QuestionTypeId
                               select new QuestionDetailDto()
                               {
                                   QuestionName = q.QuestionName,
                                   QuestionAnswer = q.QuestionAnswer,
                                   QuestionType = qt.QuestionTypeName,
                                   Category = c.CategoryName
                               }).ToList();
            ViewBag.categories = _context.Categories.ToList();
            
            return View("Update",secQuestion);
        }
        public IActionResult Updated(Question question)
        {
            
            _context.Questions.Update(question);
            _context.SaveChanges();
            return RedirectToAction("~\\Exam\\Index\\");
        }
    }
}
