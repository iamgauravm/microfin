namespace MicroFIN.Core.Contracts;

public class CreateDiaryRequest
{
    public int AgentId { get; set; }
    public int CustomerId { get; set; }
    public int DiaryNumber { get; set; }
    public DateTime DiaryStartDate { get; set; }
    public double LoanAmount { get; set; }
    public int Installment { get; set; }
    public int SchemeId { get; set; }
    public ICollection<ReferenceViewModel> References { get; set; }
}

public record ReferenceViewModel 
{
    public int AccountId { get; set; }
    public double AvailableFunds { get; set; }
    public double LoanAmount { get; set; }
}