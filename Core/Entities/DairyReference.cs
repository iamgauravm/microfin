using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFIN.Core.Entities;

public class DairyReference
{
    [Key]
    public int Id { get; set; }
    public int DairyId { get; set; }
    public int FromDairyId { get; set; }
    public double Amount { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    
    [ForeignKey("DairyId")]
    public Dairy Dairy { get; set; }
    
    [ForeignKey("FromDairyId")]
    public Dairy FromDairy { get; set; }
}