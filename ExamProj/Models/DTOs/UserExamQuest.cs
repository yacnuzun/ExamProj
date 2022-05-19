namespace ExamProj.Models.DTOs
{
    public class UserExamQuest
    {
        public int QuestionId { get; set; }
        public int ExampId { get; set; }
        public int UserId { get; set; }
        public string QuestionName { get; set; }
        public string ExamName { get; set; }
        public int ExamDuration { get; set; }
        public string ExamDescription { get; set; }
        public string QuestionAnswer { get; set; }
        public int Timer { get; set; }
    }
}
