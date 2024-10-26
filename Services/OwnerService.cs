using TechnicoApplication.Models;
using TechnicoApplication.Repositories;

namespace TechnicoApplication.Services;

public class OwnerService{
    private RepairApplicationDbContext _repairApplicationDbContext;
    public OwnerService(RepairApplicationDbContext repairApplicationDbContext){
        _repairApplicationDbContext = repairApplicationDbContext;
    }

    public void RegisterOwner(Owner owner){
        if (owner is null){
            Console.WriteLine("owner argument is null.");
            return;
        }

        Owner? ownerQueryResult = _repairApplicationDbContext.Owners.FirstOrDefault(c => c.VatNumber == owner.VatNumber);
        if (ownerQueryResult != null){
            Console.WriteLine($"Owner requested registration already exists");
            return;
        }

        //Register owner to the db.
        _repairApplicationDbContext.Owners.Add(owner);
        _repairApplicationDbContext.SaveChanges();
        Console.WriteLine("Owned Registered");
    }

    public void DisplayOwnerInfo(Owner owner){
        //Display owner info (for now all) -> security later.
        //Display owner Properties (if any)
        //Display owner Properties repairs (if any) 
    }


    public void UpdateOwnerInfo(Owner owner){ 
        //Update owner's info to the db (some attributes are not allowed to change (such as email or VAT that are considered as unique.)
    }

    public void DeleteOwner(Owner owner){
        if(owner is null){
            Console.WriteLine("owner argument is null.");
            return;
        }

        Owner? ownerQueryResult = _repairApplicationDbContext.Owners.FirstOrDefault(c => c.VatNumber == owner.VatNumber);
        if (ownerQueryResult == null){
            Console.WriteLine($"Owner requested removal does not exist");
            return;
        }

        //Delete owner from the db.
        _repairApplicationDbContext.Owners.Remove(ownerQueryResult);
        _repairApplicationDbContext.SaveChanges();
        Console.WriteLine("Owner Removed");
    }
}
