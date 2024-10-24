namespace TechnicoApplication.Models;

public class Repair{
    public enum RepairType{
        Painting,
        Insulation,
        Frames,
        Plumbing,
        ElectriicWork,
    }

    public enum RepairStatus{
        Pending,
        InProgress,
        Complete,
    }

    public DateTime ScheduledRepairDate {get; set;}
    public string? RepairDescription { get; set; } = string.Empty;
    public string? RepairAddress { get; set; } = string.Empty; 
    public RepairStatus Status{get; set;}
    public Owner? RepairOwner {get; set;}
}
