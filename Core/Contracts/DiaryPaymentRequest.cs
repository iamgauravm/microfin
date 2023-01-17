namespace MicroFIN.Core.Contracts;

public class DiaryPaymentRequest
{
    public int DiaryId { get; set; }
    public DateTime PaymentDate { get; set; }
    public double PaymentAmount { get; set; }
    public double PaymentLateAmount { get; set; }
    public double PaymentTotal { get; set; }
    public string PaymentMode { get; set; }
    public bool ClosedDiary { get; set; }
}
