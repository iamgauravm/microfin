using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFIN.Core.Entities;

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public string? Address { get; set; }
    public string ContactType { get; set; }
    public int CustomerId { get; set; }
    public int? ExistingCustomerId { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
}