using ExamProj.Models;
using ExamProj.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ExampProject.Controllers
{
    public class CategoryController : Controller
    {
        Context _context=new Context();

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c=>c.CategoryId==id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var category = _context.Categories.SingleOrDefault(c=>c.CategoryId==id);
            return View("Update", category);
        }
        [HttpPost]
        public IActionResult Updated(Category c)
        {
            _context.Categories.Update(c);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
