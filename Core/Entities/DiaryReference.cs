using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFIN.Core.Entities;

public class DiaryReference
{
    [Key]
    public int Id { get; set; }
    public int DiaryId { get; set; }
    public int FromDiaryId { get; set; }
    public double Amount { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    
    [ForeignKey("DiaryId")]
    public Diary Diary { get; set; }
    
    [ForeignKey("FromDiaryId")]
    public Diary FromDiary { get; set; }
}