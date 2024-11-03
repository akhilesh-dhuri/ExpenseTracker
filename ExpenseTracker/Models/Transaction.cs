using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ExpenseTracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [MaxLength(100, ErrorMessage = "Note cannot exceed 100 characters.")]
        public string? Note { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string? AmountWithCurrency
        {
            get
            {
                // Create a custom NumberFormatInfo
                NumberFormatInfo customFormat = new NumberFormatInfo
                {
                    CurrencySymbol = "₹",
                    CurrencyDecimalDigits = 2,
                    CurrencyDecimalSeparator = ".",
                    CurrencyGroupSeparator = ",",
                    CurrencyGroupSizes = new int[] { 3 }
                };
                return $"{this.Amount.ToString("C", customFormat)}";
            }
        }

        [NotMapped]
        public string? AmountWithSign
        {
            get
            {
                if (this.Category != null)
                {
                    if (this.Category.Type == "Income")
                    {
                        return $"+ {this.AmountWithCurrency}";
                    }
                    else
                    {
                        return $"- {this.AmountWithCurrency}";
                    }
                }
                return null;
            }
        }
    }
}
