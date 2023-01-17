using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFIN.Core.Entities;

public class InvestorTransaction
{
    public int Id { get; set; }
    [Column(TypeName = "date")]
    public DateTime TransDate { get; set; }
    [DefaultValue(0)]
    public double Amount { get; set; }
    public string TransType { get; set; } // Add Fund, Transfer Fund, Withdrawal Fund
    public string Description { get; set; }
    public int InvestorId { get; set; }
    public int? DairyId { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
}

