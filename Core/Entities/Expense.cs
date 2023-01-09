using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFIN.Core.Entities;

public class Expense
{
    public int Id { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public double Amount { get; set; }
    public bool IsActive { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
}