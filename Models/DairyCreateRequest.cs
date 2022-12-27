namespace MicroFIN.Models;

public class DairyCreateRequest
{
    public int Id { get; set; }
    public int DailyNumber { get; set; }
    public int CustomerId { get; set; }
    public int AgentId { get; set; }
    public DateTime StartDate { get; set; }
    public double LoanAmount { get; set; }
    public int Installment { get; set; }
    public double TotalAmount { get; set; }
    public bool IsActive { get; set; }
}