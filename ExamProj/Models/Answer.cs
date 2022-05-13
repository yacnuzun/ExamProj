namespace ExamProj.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string? AnswerText { get; set; }
        public string? DescriptionAnswer { get; set; }
        public int QuestionId { get; set; }
    }
}
