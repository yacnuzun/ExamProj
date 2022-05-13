﻿using System.ComponentModel.DataAnnotations;

namespace ExamProj.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
