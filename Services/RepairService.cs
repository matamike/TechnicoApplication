using TechnicoApplication.Models;
using TechnicoApplication.Repositories;

namespace TechnicoApplication.Services;

public class RepairService{
    private RepairApplicationDbContext _repairApplicationDbContext;
    public RepairService(RepairApplicationDbContext repairApplicationDbContext) => _repairApplicationDbContext = repairApplicationDbContext;

    public void RegisterRepair(Repair repair){
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
        _repairApplicationDbContext.Repairs.Add(repair);
        _repairApplicationDbContext.SaveChanges();
        Console.WriteLine("Repair Registered");
    }

    public void SearchRepair(Repair repair){
        //Find a repair corresponding to a property given that it exists
        if (repair == null){
            Console.WriteLine("repair argument was null.");
            return;
        }

        if (repair.owner == null)
        {
            Console.WriteLine("Repair's Owner was not set");
            return;
        }

        if (repair.property == null)
        {
            Console.WriteLine("Repair's Property was not set");
            return;
        }

        Owner? ownerQueeryResult = _repairApplicationDbContext.Owners.FirstOrDefault(o => o.VatNumber == repair.owner.VatNumber);
        Property? propertyQueryResult = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == repair.property.PropertyID);
        if (ownerQueeryResult == null || propertyQueryResult == null){
            Console.WriteLine("Repair requested update contains property or owner not registered.");
            return;
        }

        Repair? repairOwnerQueryResult = _repairApplicationDbContext.Repairs.FirstOrDefault(r => r.owner == ownerQueeryResult && r.property == propertyQueryResult);
        if (repairOwnerQueryResult == null){
            Console.WriteLine("Repair not found in database.");
            return;
        }

        Console.WriteLine($"==============Repair=========== \n" +
                          $" Repair Type: {repairOwnerQueryResult.RType} \n" +
                          $" Repair Cost: {repairOwnerQueryResult.Cost} \n" +
                          $" Repair Status: {repairOwnerQueryResult.Status} \n" +
                          $" Repair Description: {repairOwnerQueryResult.Description} \n" +
                          $" Repair Date: {repairOwnerQueryResult.ScheduledRepairDate} \n" +
                          $"===============================");
    }


    public void UpdateRepairInfo(Repair repair){
        if (repair == null)
        {
            Console.WriteLine("repair argument was null.");
            return;
        }

        if (repair.owner == null)
        {
            Console.WriteLine("Repair's Owner was not set");
            return;
        }

        if (repair.property == null)
        {
            Console.WriteLine("Repair's Property was not set");
            return;
        }

        Owner? ownerQueeryResult = _repairApplicationDbContext.Owners.FirstOrDefault(o => o.VatNumber == repair.owner.VatNumber);
        Property? propertyQueryResult = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == repair.property.PropertyID);
        if (ownerQueeryResult == null || propertyQueryResult == null)
        {
            Console.WriteLine("Repair requested update contains property or owner not registered.");
            return;
        }

        Repair? repairOwnerQueryResult = _repairApplicationDbContext.Repairs.FirstOrDefault(r => r.owner == ownerQueeryResult && r.property == propertyQueryResult);
        if (repairOwnerQueryResult == null)
        {
            Console.WriteLine("Repair not found in database.");
            return;
        }

        repairOwnerQueryResult.ScheduledRepairDate = repair.ScheduledRepairDate;
        repairOwnerQueryResult.Cost = repair.Cost;
        repairOwnerQueryResult.RType = repair.RType;
        repairOwnerQueryResult.Description = repair.Description;
        repairOwnerQueryResult.Status = repair.Status;
        _repairApplicationDbContext.SaveChanges();
        Console.WriteLine("Changes Updated Successfully.");
    }

    public void DeleteRepair(Repair repair){
        if (repair == null){
            Console.WriteLine("repair argument was null.");
            return;
        }

        if (repair.owner == null){
            Console.WriteLine("Repair's Owner was not set");
            return;
        }

        if (repair.property == null){
            Console.WriteLine("Repair's Property was not set");
            return;
        }

        Owner? ownerQueeryResult = _repairApplicationDbContext.Owners.FirstOrDefault(o => o.VatNumber == repair.owner.VatNumber);
        Property? propertyQueryResult = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == repair.property.PropertyID);
        if (ownerQueeryResult == null || propertyQueryResult == null){
            Console.WriteLine("Repair requested removal contains property or owner not registered.");
            return;
        }

        Repair? repairOwnerQueryResult = _repairApplicationDbContext.Repairs.FirstOrDefault(r => r.owner == ownerQueeryResult && r.property == propertyQueryResult);
        if (repairOwnerQueryResult == null){
            Console.WriteLine("Repair not found in database.");
            return;
        }


        _repairApplicationDbContext.Repairs.Remove(repairOwnerQueryResult);
        _repairApplicationDbContext.SaveChanges();
        Console.WriteLine("Repair Removed");
    }
}
