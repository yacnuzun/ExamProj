using System.ComponentModel.DataAnnotations;

namespace ExampProject.Models
{
    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }
        public string? ChoiceText { get; set; }
        public int QuestionId { get; set; }
    }
}
