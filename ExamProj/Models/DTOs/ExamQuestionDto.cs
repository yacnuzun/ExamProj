namespace ExamProj.Models.DTOs
{
    public class ExamQuestionDTO
    {
        public int QuestionId { get; set; }
        public string? QuestionName { get; set; }
        public string? QuestionAnswer { get; set; }
        public string? QuestionTypeName { get; set; }
        public string? CategoryName { get; set; }
    }
}
