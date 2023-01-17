using System.ComponentModel;

namespace MicroFIN.Core.Entities;

public class Investor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public string? Address { get; set; }
    [DefaultValue(0)]
    public double AvailableFunds { get; set; }
    [DefaultValue(0)]
    public double TotalFunding { get; set; }
    [DefaultValue(0)]
    public double TotalRecovery { get; set; }
    [DefaultValue(0)]
    public double TotalWithdrawal { get; set; }
    public bool IsActive { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    
    public virtual ICollection<Diary> Dairies { get; set; }
}