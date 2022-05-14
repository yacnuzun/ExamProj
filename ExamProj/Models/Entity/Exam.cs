using System.ComponentModel.DataAnnotations;

namespace ExamProj.Models.Entity
{
    public class Exam
    {
        [Key]
        public int ExampId { get; set; }
        public string? ExamName { get; set; }
        public int ExamDuration { get; set; }
        public string? ExamDescription { get; set; }
        //public int SuccessStatus { get; set; }
    }
}
