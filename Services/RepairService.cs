using TechnicoApplication.Models;
using TechnicoApplication.Repositories;

namespace TechnicoApplication.Services;

public class RepairService{
    private RepairApplicationDbContext _repairApplicationDbContext;
    public RepairService(RepairApplicationDbContext repairApplicationDbContext) => _repairApplicationDbContext = repairApplicationDbContext;

    public void RegisterRepair(Repair repair){
        //Register a new repair
        if (repair == null){
            Console.WriteLine("property argument was null.");
            return;
        }

        if (repair.owner == null){
            Console.WriteLine("Owner for whom Property requested repair not set");
            return;
        }

        if (repair.property == null){
            Console.WriteLine("Property requesting repair not set");
            return;
        }

        Property? queryProperty = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == repair.property.PropertyID);
        Owner? queryOwner = _repairApplicationDbContext.Owners.FirstOrDefault(p => p.VatNumber == repair.owner.VatNumber);


        if (queryProperty == null){
            Console.WriteLine($"Property requesting repair is not registered.");
            return;
        }

        
        if (queryOwner == null){
            Console.WriteLine("Property's Owner is not registered.");
            return;
        }

        repair.owner = queryOwner;
        repair.property = queryProperty;

        //Register Repair
        _repairApplicationDbContext.Repairs.Add(repair);
        _repairApplicationDbContext.SaveChanges();
        Console.WriteLine("Repair Registered");
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
