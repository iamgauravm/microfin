namespace MicroFIN.Models;

public class ExpenseViewModel
{
    public int Id { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public double Amount { get; set; }
}