using System.ComponentModel.DataAnnotations;

namespace ExampProject.Models
{
    public class Exam
    {
        [Key]
        public int ExampId { get; set; }
        public string? ExamName { get; set; }
        public string? ExamDuration { get; set; }
        public string? ExamDescription { get; set; }
    }
}
