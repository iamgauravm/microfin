namespace MicroFIN.Models;

public class CustomerViewRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
}

public class AgentViewRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public string? Address { get; set; }
}