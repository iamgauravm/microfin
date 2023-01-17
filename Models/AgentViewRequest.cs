﻿namespace MicroFIN.Models;

public class AgentViewRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public string? Address { get; set; }
    public string? Remarks { get; set; }
}