namespace ExamProj.Models.DTOs
{
    public class UserExamDto
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public string ExamDescription { get; set; }
        public int ExamDuration { get; set; }
    }
}
