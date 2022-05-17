using ExamProj.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ExamProj.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=ExamDb; Trusted_Connection=True;");
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Question>? Questions { get; set; }
        public DbSet<Choice>? Choices { get; set; }
        public DbSet<Exam>? Exams { get; set; }
        public DbSet<QuestionType>? QuestionTypes { get; set; }
        public DbSet<Answer>? Answers { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Status>? Statuses { get; set; }
        public DbSet<UserExam>? UserExams { get; set; }
    }
}
