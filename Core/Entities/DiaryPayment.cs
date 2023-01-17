using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFIN.Core.Entities;

public class DiaryPayment
{
    public int Id { get; set; }
    public int DiaryId { get; set; }
    public double Amount { get; set; }
    public double LateFee { get; set; }
    public double Total { get; set; }
    public bool IsCompleted { get; set; }
    public string PaymentMode { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    
    [ForeignKey("DiaryId")]
    public Diary? Diary { get; set; }
}