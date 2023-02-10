namespace MicroFIN.Models
{
    public class ReportCustomerViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string? FatherName { get; set; }
        public int DiaryId { get; set; }
        public int DiaryNumber { get; set; }
        public double LoanAmount { get; set; }
        public double RecoveryAmount { get; set; }
        public double PaidAmount { get; set; }
        public double BalanceAmount { get; set; }
        public bool IsCompleted { get; set; }
    }
}
