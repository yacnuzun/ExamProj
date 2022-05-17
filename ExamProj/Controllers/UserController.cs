using ExamProj.Models;
using ExamProj.Models.DTOs;
using ExamProj.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ExamProj.Controllers
{
    public class UserController : Controller
    {
        Context _context = new Context();
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Indexed(User user)
        {
            int result = _context.Users.Where(u => u.UserId == user.UserId && u.Password == user.Password).Count();
            var resultd = _context.Users.Where(u => u.UserId == user.UserId && u.Password == user.Password).ToList();
           

            if (result != 0)
            {
                if (resultd.Where(r=>r.UserStatusId==1).Count()!=0)
                {
                    return Redirect("~/Category/Index");
                }
                return RedirectToAction("UserIndex");
            }

            return RedirectToAction("Index");
        }
        public IActionResult UserIndex(List<Exam> exams)
        {
            exams = _context.Exams.ToList();
            return View(exams);
        }
        public IActionResult UserExamp(UserExamDto userExamDto,int id)
        {
           var userExamDto = (from u in _context.Users.Where(u => u.UserId == id)
                          join eu in _context.UserExams
                          on u.UserId equals eu.UserId
                          join e in _context.Exams
                          on eu.ExampId equals e.ExampId
                          select new UserExamDto()
                          {
                              UserId = u.UserId,
                              ExamDescription = e.ExamDescription,
                              ExamDuration = e.ExamDuration,
                              ExamId = e.ExampId,
                              ExamName = e.ExamName
                          }).ToList();
            return View(userExamDto);
        }
    }
}
