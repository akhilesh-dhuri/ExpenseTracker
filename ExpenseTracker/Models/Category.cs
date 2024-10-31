﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Category
    {
        [Key] 
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [Column(TypeName = "nvarchar(50)")] 
        public string? Title { get; set; }

        [Required(ErrorMessage = "Icon is required.")]
        [Column(TypeName = "nvarchar(100)")]
        public string? Icon { get; set; } = "";

        [Required(ErrorMessage = "Type is required.")]
        [Column(TypeName = "nvarchar(10)")]
        public string? Type { get; set; } = "Expense";
    }
}
