using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExpenseManagement.Models
{
    public class ExpenseEntity
    {
        [Key]
        public int ExpenseId { get; set; }

        [Required (ErrorMessage = "Please Select Expense Date")]
        [DataType (DataType.Date)]
        [Display(Name ="Expense Date")]
        public DateTime ExpenseDate { get; set;}

        [Required(ErrorMessage = "Please enter Expense given to details")]
        [MinLength(3, ErrorMessage ="the name of expense is too short")]
        [Display(Name ="Paid to ")]
        public string ExpenseGivenTo { get; set;}

        [Required(ErrorMessage = "Please enter Expense Amount")]
        [Range(0, double.MaxValue,ErrorMessage ="Please enter valid expense amount")]
        [Display(Name = "Expense Amount ")]
        public double ExpenseAmount { get; set;}

        [Display(Name = "Expense Category ")]

        //adding relation expenses with expenses category with FK***
        public int ExpenseCategoryId { get; set; }

        [ForeignKey("ExpenseCategoryId")]
        public virtual ExpenseCategoryEntity?   ExpenseCategory { get; set; }
       
    }
}
