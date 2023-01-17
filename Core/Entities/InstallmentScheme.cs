using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFIN.Core.Entities;

public class InstallmentScheme
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int InstallmentCount { get; set; }
    [Column(TypeName = "decimal(10, 4)")]
    public decimal RateInterest { get; set; }
    public bool IsActive { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
}