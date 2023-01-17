namespace MicroFIN.Core.Entities;

public class Agent
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public string? Address { get; set; }
    public int? DefaultInstallments { get; set; }
    public bool IsActive { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    
    public virtual ICollection<Diary> Dairies { get; set; }
}