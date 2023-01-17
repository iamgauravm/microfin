using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MicroFIN.Core.Contracts;

namespace MicroFIN.Core.Entities;

public class Account
{
    public int Id { get; set; }
    public string AccountName { get; set; }
    public AccountType AccountType { get; set; }
    public string AccountTypeText { get; set; } = string.Empty;
    [DefaultValue("")]
    public string? Mobile { get; set; } = string.Empty;
    [DefaultValue("")]
    public string? Address { get; set; } = string.Empty;
    [DefaultValue("")]
    public string? FatherName { get; set; } = string.Empty;
    [DefaultValue("")]
    public string? BusinessName { get; set; } = string.Empty;
    [DefaultValue(0)]
    public int? CreditScore { get; set; } = 0;
    [DefaultValue("")]
    public string? Remarks { get; set; } = string.Empty;
    [DefaultValue(0)]
    public double AvailableFunds { get; set; } = 0;
    [DefaultValue(0)]
    public double TotalFunding { get; set; } = 0;
    [DefaultValue(0)]
    public double TotalRecovery { get; set; } = 0;
    [DefaultValue(0)]
    public double TotalWithdrawal { get; set; } = 0;

    [DefaultValue(false)] 
    public bool IsCash { get; set; } = false;
    [DefaultValue(false)]
    public bool IsDefault { get; set; } = false;
    [DefaultValue(0)]
    public int ParentAccountId { get; set; } = 0;
    [DefaultValue(true)]
    public bool IsActive { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    
    
    
    [ForeignKey("CreatedBy")]
    public User? CreateByUser { get; set; }
    
    [ForeignKey("ModifiedBy")]
    public User? ModifyByUser { get; set; }
    
}