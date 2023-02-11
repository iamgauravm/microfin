namespace MicroFIN.Models;

public class DashboardCounterViewModel
{
    public int Diaries { get; set; }
    public int Customers { get; set; }
    public int RevenueTotal { get; set; }
    public int ExpensesTotal { get; set; }
    public double TotalCredit { get; set; }
    public double TotalDebit { get; set; }
    public double TotalBalance { get; set; }
}