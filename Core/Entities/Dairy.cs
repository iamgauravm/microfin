using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFIN.Core.Entities;

public class Dairy
{
    public int Id { get; set; }
    public int DailyNumber { get; set; }
    public int CustomerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double LoanAmount { get; set; }
    public double InterestRate { get; set; }
    public string TenureType { get; set; }
    public int Tenure { get; set; }
    public double TotalAmount { get; set; }
    public double TotalBalanceAmount { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsActive { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
    public virtual ICollection<DairyInstallment> DairyInstallments { get; set; }

}