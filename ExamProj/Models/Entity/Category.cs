using System.ComponentModel.DataAnnotations;

namespace ExamProj.Models.Entity
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
