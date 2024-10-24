using TechnicoApplication.Models.PropertyOwner;

namespace TechnicoApplication.Models.PropertyRepair;

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

    private DateTime _scheduledRepairDate;
    private string? _repairDescription;
    private string? _repairAddress;
    private RepairStatus _repairStatus;
    private Owner? _repairOwner;
}
