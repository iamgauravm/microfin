namespace MicroFIN.Models;

public class DairyResponseViewModel
{
    public int Id { get; set; }
    public int DairyNumber { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerFatherName { get; set; }
    public string CustomerMobile { get; set; }
    public int? AgentId { get; set; }
    public bool? HasAgent { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public double LoanAmount { get; set; }
    public int Installment { get; set; }
    public double TotalAmount { get; set; }
    public double TotalBalanceAmount { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsActive { get; set; }
    public List<DairyInstallmentResponseViewModel> Installments { get; set; }
}

public class DairyInstallmentResponseViewModel
{
    public int Id { get; set; }
    public int InstallmentNumber { get; set; }
    public DateTime InstallmentDate { get; set; }
    public double InstallmentAmount { get; set; }
    public double PaidAmount { get; set; }
    public double BalanceAmount { get; set; }
    public bool IsClosed{ get; set; }
}

public class DairyInstallmentPaymentRequest
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public bool IsClosed{ get; set; }
}