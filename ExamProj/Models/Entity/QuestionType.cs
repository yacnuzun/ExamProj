using System.ComponentModel.DataAnnotations;

namespace ExamProj.Models.Entity
{
    public class QuestionType
    {
        [Key]
        public int QuestionTypeId { get; set; }
        public string? QuestionTypeName { get; set; }
    }
}
