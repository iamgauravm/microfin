using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFIN.Core.Entities;

public class Diary
{
    public int Id { get; set; }
    public int DiaryNumber { get; set; }
    public int CustomerId { get; set; }
    public int? AgentId { get; set; }
    public bool? HasAgent { get; set; }
    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }
    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }
    
    [DefaultValue(1)]
    public int InstallmentSchemeId { get; set; }
    [DefaultValue(120)]
    public int Installment { get; set; }
    public double LoanAmount { get; set; }
    public double RecoveryAmount { get; set; }
    public double TotalPaidAmount { get; set; }
    public double TotalBalanceAmount { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsActive { get; set; }

    public int AccountId { get; set; }
    
    public int? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    [ForeignKey("CustomerId")]
    public Account Customer { get; set; }
    
    [ForeignKey("AgentId")]
    public Account? Agent { get; set; }
    
    [ForeignKey("AccountId")]
    public Account? Account { get; set; }
    
    [ForeignKey("InstallmentSchemeId")]
    public InstallmentScheme? InstallmentScheme { get; set; }
    public virtual ICollection<DiaryInstallment> DiaryInstallments { get; set; }
    public virtual ICollection<DiaryPayment> DiaryPayments { get; set; }
    
    
    

}