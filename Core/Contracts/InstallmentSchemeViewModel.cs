namespace MicroFIN.Core.Contracts;

public class InstallmentSchemeViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int InstallmentCount { get; set; }
    public decimal RateInterest { get; set; }
}