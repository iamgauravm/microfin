using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFIN.Core.Entities;

public class Dairy
{
    public int Id { get; set; }
    public int DairyNumber { get; set; }
    public int CustomerId { get; set; }
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
    public int? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
    
    [ForeignKey("AgentId")]
    public Agent? Agent { get; set; }
    
    public virtual ICollection<DairyInstallment> DairyInstallments { get; set; }

}