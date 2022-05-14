using System.ComponentModel.DataAnnotations;

namespace ExamProj.Models.Entity
{
    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }
        public string? ChoiceText { get; set; }
        public int QuestionId { get; set; }
    }
}
