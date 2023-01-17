namespace MicroFIN.Core.Contracts;

public class InvestorAddFundRequest
{
    public int AccountId { get; set; }
    public DateTime TransDate { get; set; }
    public int Amount { get; set; }
    public string Mode { get; set; }
}