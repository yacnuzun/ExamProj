using System.ComponentModel.DataAnnotations;

namespace ExamProj.Models.Entity
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string? QuestionName { get; set; }
        public bool IsTrue { get; set; }
        public string? QuestionAnswer { get; set; }
        public int QuestionTypeId { get; set; }
        public int CategoryId { get; set; }
        public int ExampId { get; set; }
    }
}
