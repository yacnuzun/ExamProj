using System.ComponentModel.DataAnnotations;

namespace ExampProject.Models
{
    public class QuestionType
    {
        [Key]
        public int QuestionTypeId { get; set; }
        public string? QuestionTypeName { get; set; }
        public int QuestionId { get; set; }
    }
}
