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
                return RedirectToAction("UserIndex",user);
            }

            return RedirectToAction("Index");
        }
        public IActionResult UserIndex(User user,List<UserExamQuest> userExams)
        {
            userExams =  (from u in _context.Users.Where(u => u.UserId == user.UserId)
                                                join eu in _context.UserExams
                                                on u.UserId equals eu.UserId
                                                join e in _context.Exams
                                                on eu.ExampId equals e.ExampId
                                                join q in _context.Questions
                                                on e.ExampId equals q.ExampId
                                                select new UserExamQuest()
                                                {
                                                    ExamDuration = e.ExamDuration,
                                                    ExamDescription= e.ExamDescription,
                                                    ExamName = e.ExamName,
                                                    UserId = u.UserId,
                                                    QuestionAnswer = q.QuestionAnswer,
                                                    Timer = e.ExamDuration,
                                                    ExampId = e.ExampId,
                                                    QuestionName = q.QuestionName,
                                                    QuestionId = q.QuestionId
                                                }).ToList();
            return RedirectToAction("UserExamp",user);
        }
        public IActionResult UserExamp(User user,List<UserExamQuest> userExamQuest,Answer answer)
        {
            if (answer.QuestionId!=0)
            {
                int qid = answer.QuestionId;
            }
            userExamQuest = (from u in _context.Users.Where(u => u.UserId == user.UserId)
                         join eu in _context.UserExams
                         on u.UserId equals eu.UserId
                         join e in _context.Exams
                         on eu.ExampId equals e.ExampId
                         join q in _context.Questions.Where(q=>q.QuestionId > answer.QuestionId)
                         on e.ExampId equals q.ExampId
                         select new UserExamQuest()
                         {
                             ExamDuration = e.ExamDuration,
                             ExamDescription = e.ExamDescription,
                             ExamName = e.ExamName,
                             UserId = u.UserId,
                             QuestionAnswer = q.QuestionAnswer,
                             Timer = e.ExamDuration,
                             ExampId = e.ExampId,
                             QuestionName = q.QuestionName,
                             QuestionId = q.QuestionId
                         }).ToList();
            return View(userExamQuest);
        }
        public IActionResult UserExamped(UserExamQuest userExamQuest)
        {
            Answer answer = new Answer();
            answer.QuestionId=userExamQuest.QuestionId;
            answer.AnswerText = userExamQuest.QuestionAnswer;
            answer.DescriptionAnswer = userExamQuest.QuestionAnswer;
            _context.Add(answer);
            _context.SaveChanges();
            return RedirectToAction("UserExamp",answer);
        }
    }
}
