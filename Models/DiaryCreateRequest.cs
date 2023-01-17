namespace MicroFIN.Models;

public class DiaryCreateRequest
{
    public int AgentId { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerFatherName { get; set; }
    public string CustomerMobile { get; set; }
    public string CustomerBusinessName { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerRemarks { get; set; }
    public int DiaryNumber { get; set; }
    public DateTime DiaryStartDate { get; set; }
    public double LoanAmount { get; set; }
    public int Installment { get; set; }
    public int SchemeId { get; set; }
    public ICollection<ReferenceDiaryViewModel> RefDiaries { get; set; }
}

public record ReferenceDiaryViewModel 
{
    // public int Id { get; set; }
    public int AccountId { get; set; }
    public double AvailableFunds { get; set; }
    public double LoanAmount { get; set; }
}