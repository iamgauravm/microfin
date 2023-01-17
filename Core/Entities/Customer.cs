using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFIN.Core.Entities;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? FatherName { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string Mobile { get; set; }
    public string? BusinessName { get; set; }
    public string? Remarks { get; set; }
    public bool IsActive { get; set; }
    public int? CreditScore { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    
    public virtual ICollection<Contact> Contacts { get; set; }
    
    [ForeignKey("CreatedBy")]
    public User? CreateByUser { get; set; }
    
    [ForeignKey("ModifiedBy")]
    public User? ModifyByUser { get; set; }
    
}