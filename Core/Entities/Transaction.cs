using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MicroFIN.Core.Contracts;

namespace MicroFIN.Core.Entities;

public class Transaction
{
    public int Id { get; set; }
    public TransactionType TransactionType { get; set; }
    public string TransactionTypeText { get; set; } // +GivenBy Diary/Investor, -TransferTo Dairy/Investor, +Installment Payment
    [Column(TypeName = "date")]
    public DateTime TransDate { get; set; }
    [DefaultValue("")]
    public string Description { get; set; }
    [DefaultValue("CASH")]
    public string PaymentMode { get; set; }
    [DefaultValue(0)]
    public double Amount { get; set; }
    [DefaultValue(0)]
    public double LateFee { get; set; }
    [DefaultValue(0)]
    public double Total { get; set; }
    
    // Add fund to Cash
    public int? DiaryId { get; set; }
    public int? InvestorId { get; set; }
    public int? FromDiaryId { get; set; }
    
    
    [DefaultValue(false)]
    public bool IsCompleted { get; set; }
    
    public int? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    
    [ForeignKey("DiaryId")]
    public Account? Diary { get; set; }
    
    [ForeignKey("FromDiaryId")]
    public Account? FromDiary { get; set; }
    
    [ForeignKey("InvestorId")]
    public Account? Investor { get; set; }
}