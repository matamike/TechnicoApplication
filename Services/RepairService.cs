using TechnicoApplication.Models;
using TechnicoApplication.Repositories;

namespace TechnicoApplication.Services;

public class RepairService{
    private RepairApplicationDbContext _repairApplicationDbContext;
    public RepairService(RepairApplicationDbContext repairApplicationDbContext) => _repairApplicationDbContext = repairApplicationDbContext;

    public void RegisterRepair(Repair repair){
        //Register a new repair
    }

    public void SearchRepair(Repair repair){
        //Find a repair corresponding to a property given that it exists
    }


    public void UpdateRepairInfo(Repair repair){
        //update selected repair's info (with validation ofc)
    }

    public void DeleteRepair(Repair repair){
        //Remove a repair that corresponds to the logged in user's 
    }
}
