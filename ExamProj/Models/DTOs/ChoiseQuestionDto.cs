namespace ExamProj.Models.DTOs
{
    public class ChoiseQuestionDto
    {
        public int QuestionTypeId { get; set; }
        public int ExamId { get; set; }
        public int CategoryId { get; set; }
        public bool IsTrue { get; set; }
        public string? ChoiseText { get; set; }
        public string? QuestionAnswer { get; set; }
        public string? QuestionName { get; set; }

    }
}
