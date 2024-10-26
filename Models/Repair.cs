namespace TechnicoApplication.Models;

public class Repair{
    public DateTime ScheduledRepairDate {get; set;}
    public string? Description { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty; 
    public RepairStatus Status{get; set;}

    public RepairType RType { get; set;}
    public Owner? Owner {get; set;}
}
