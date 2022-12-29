namespace MicroFIN.Models;

public class DairyCreateRequest
{
    public int AgentId { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerFatherName { get; set; }
    public string CustomerMobile { get; set; }
    public string CustomerBusinessName { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerRemarks { get; set; }
    public int DailyNumber { get; set; }
    public DateTime DairyStartDate { get; set; }
    public double LoanAmount { get; set; }
    public int Installment { get; set; }
    public ICollection<ReferenceDairyViewModel> RefDairies { get; set; }
}

public record ReferenceDairyViewModel 
{
    // public int Id { get; set; }
    public int DailyNumber { get; set; }
    public double PaidAmount { get; set; }
    public double LoanAmount { get; set; }
}