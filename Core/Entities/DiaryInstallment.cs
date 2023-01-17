using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFIN.Core.Entities;

public class DiaryInstallment
{
    public int Id { get; set; }
    public int InstallmentNumber { get; set; }
    public DateTime InstallmentDate { get; set; }
    public double InstallmentAmount { get; set; }
    public double PaidAmount { get; set; }
    public double BalanceAmount { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int DiaryId { get; set; }
}