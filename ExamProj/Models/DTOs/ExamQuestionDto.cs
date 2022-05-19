namespace ExamProj.Models.DTOs
{
    public class ExamQuestionDTO
    {
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }
        public string? QuestionName { get; set; }
        public string? QuestionAnswer { get; set; }
        public string? QuestionTypeName { get; set; }
        public string? CategoryName { get; set; }
    }
}
