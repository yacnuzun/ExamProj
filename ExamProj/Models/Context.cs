using ExamProj.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ExamProj.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=ExampDb; Trusted_Connection=True;");
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Question>? Questions { get; set; }
        public DbSet<Choice>? Choices { get; set; }
        public DbSet<Exam>? Exams { get; set; }
        public DbSet<QuestionType>? QuestionTypes { get; set; }
        public DbSet<Answer>? Answers { get; set; }
    }
}
