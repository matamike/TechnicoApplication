using TechnicoApplication.Models;
using TechnicoApplication.Repositories;

namespace TechnicoApplication.Services;

public class OwnerService{
    private RepairApplicationDbContext _repairApplicationDbContext;
    public OwnerService(RepairApplicationDbContext repairApplicationDbContext) => _repairApplicationDbContext = repairApplicationDbContext;

    public void RegisterOwner(Owner owner){
        if (owner is null){
            Console.WriteLine("owner argument is null.");
            return;
        }

        Owner? ownerVatQueryResult = _repairApplicationDbContext.Owners.FirstOrDefault(c => c.VatNumber == owner.VatNumber);
        Owner? ownerEmailQueryResultt = _repairApplicationDbContext.Owners.FirstOrDefault(c => c.Email == owner.Email);
        if (ownerVatQueryResult != null){
            Console.WriteLine($"Owner registration with the VatNumber provided already exists.");
            return;
        }

        if (ownerEmailQueryResultt != null){
            Console.WriteLine($"Owner registration with the Email provided already exists.");
            return;
        }

        if (owner.Email == null || owner.Email == string.Empty){
            Console.WriteLine($"Owner input email is null or empty");
            return;
        }

        if (owner.VatNumber == null || owner.VatNumber == string.Empty){
            Console.WriteLine($"Owner input VatNumber is null or empty");
            return;
        }

        _repairApplicationDbContext.Owners.Add(owner);
        _repairApplicationDbContext.SaveChanges();
        Console.WriteLine("Owned Registered");
    }

    public void DisplayOwnerInfo(Owner owner){
        if (owner is null){
            Console.WriteLine("owner argument is null.");
            return;
        }

        Owner? ownerQueryResult = _repairApplicationDbContext.Owners.FirstOrDefault(c => c.VatNumber == owner.VatNumber);
        if (ownerQueryResult == null){
            Console.WriteLine($"Owner requested display does not exist");
            return;
        }

        Console.WriteLine($" Name: {ownerQueryResult.Name} \n" +
                          $" Surname: {ownerQueryResult.Surname} \n" +
                          $" Email:{ownerQueryResult.Email} \n" +
                          $" Address: {ownerQueryResult.Address} \n" +
                          $" VAT: {ownerQueryResult.VatNumber} \n" +
                          $" PhoneNumber: {ownerQueryResult.PhoneNumber} \n");

        //Display owner Properties (if any) //TODO
        //Display owner Properties repairs //TODO 
    }

    public void UpdateOwnerInfo(Owner owner){
        if (owner is null){
            Console.WriteLine("owner argument is null.");
            return;
        }

        Owner? ownerQueryResult = _repairApplicationDbContext.Owners.FirstOrDefault(c => c.VatNumber == owner.VatNumber);
        if (ownerQueryResult == null){
            Console.WriteLine($"Owner requested update changes does not exist");
            return;
        }

        if (ownerQueryResult.VatNumber != owner.VatNumber){
            Console.WriteLine($"Detected Change(VAT). Changing Owner's VAT is not allowed.");
        }

        if (ownerQueryResult.Email != owner.Email){
            Console.WriteLine($"Detected Change(Email). Changing Owner's Email is not allowed.");
        }

        ownerQueryResult.Name = owner.Name;
        ownerQueryResult.Surname = owner.Surname;
        ownerQueryResult.Address = owner.Address;
        ownerQueryResult.PhoneNumber = owner.PhoneNumber;
        _repairApplicationDbContext.SaveChanges();
        Console.WriteLine("Changes Updated Successfully.");
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
