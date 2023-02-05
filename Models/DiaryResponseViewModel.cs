namespace MicroFIN.Models;

public class DiaryResponseViewModel
{
    public int Id { get; set; }
    public int DiaryNumber { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerFatherName { get; set; }
    public string CustomerMobile { get; set; }
    public string CustomerBusiness { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerRemarks { get; set; }
    public int? AgentId { get; set; }
    public bool? HasAgent { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double LoanAmount { get; set; }
    public int Installment { get; set; }
    public double TotalAmount { get; set; }
    public double TotalBalanceAmount { get; set; }
    public double TodayBalance { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsActive { get; set; }
    public List<DiaryInstallmentResponseViewModel> Installments { get; set; }
    public List<DiaryReffViewModel> FromDairies { get; set; }
    public List<DiaryReffViewModel> ToDairies { get; set; }
}
public class DiaryInstallmentResponseViewModel
{
    public int Id { get; set; }
    public int InstallmentNumber { get; set; }
    public DateTime InstallmentDate { get; set; }
    public double InstallmentAmount { get; set; }
    public double PaidAmount { get; set; }
    public double BalanceAmount { get; set; }
    public bool IsClosed{ get; set; }
}


public class DiaryReffViewModel
{
    public DateTime TransferDate { get; set; }
    public double TransferAmount { get; set; }
    public string AccountName { get; set; }
    public string Invester { get; set; }
}

public class DiaryInstallmentPaymentRequest
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public bool IsClosed{ get; set; }
}