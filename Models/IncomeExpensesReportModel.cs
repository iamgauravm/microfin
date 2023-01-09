namespace MicroFIN.Models;

public class IncomeExpensesReportModel
{
    public bool IsIncome { get; set; }
    public string Category { get; set; }
    public decimal Amount { get; set; }
}