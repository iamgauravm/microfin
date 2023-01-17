namespace MicroFIN.Models;

public class AccountViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FatherName { get; set; }
    public string Business { get; set; }
    public string Mobile { get; set; }
    public string? Address { get; set; }
    public string? Remarks { get; set; }
    public int? AccountTypeId { get; set; }
    public string? AccountType { get; set; }
    public double AvailableFunds { get; set; } = 0;
    public double TotalFunding { get; set; } = 0;
    public double TotalRecovery { get; set; } = 0;
    public double TotalWithdrawal { get; set; } = 0;
}