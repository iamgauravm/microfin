namespace MicroFIN.Models;

public class LedgerViewModel
{
    public DateTime TransDate { get; set; }
    public string Particular { get; set; } = string.Empty;
    public double Credit { get; set; }
    public double Debit { get; set; }
    public double Balance { get; set; }
}