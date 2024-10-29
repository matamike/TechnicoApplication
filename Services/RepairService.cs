using TechnicoApplication.Models;
using TechnicoApplication.Repositories;
using TechnicoApplication.Responses;

namespace TechnicoApplication.Services;

public class RepairService{
    private RepairApplicationDbContext _repairApplicationDbContext;
    public RepairService(RepairApplicationDbContext repairApplicationDbContext) => _repairApplicationDbContext = repairApplicationDbContext;

    public ImmutableResponseStatus RegisterRepair(Repair repair){
        if (repair == null) return new ImmutableResponseStatus(false, "repair argument was null.");
        if (repair.owner == null) return new ImmutableResponseStatus(false, "Owner for whom Property requested repair not set");
        if (repair.property == null) return new ImmutableResponseStatus(false, "Property field requesting repair not set");
         
        Property? queryProperty = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == repair.property.PropertyID);
        Owner? queryOwner = _repairApplicationDbContext.Owners.FirstOrDefault(p => p.VatNumber == repair.owner.VatNumber);

        if (queryProperty == null) return new ImmutableResponseStatus(false, "Property requesting repair is not registered.");
        if (queryOwner == null) return new ImmutableResponseStatus(false, "Property's Owner is not registered.");

        repair.owner = queryOwner;
        repair.property = queryProperty;
        _repairApplicationDbContext.Repairs.Add(repair);
        _repairApplicationDbContext.SaveChanges();
        return new ImmutableResponseStatus(true, "Repair Registered");
    }

    public ImmutableResponseStatus SearchRepair(Repair repair){
        if (repair == null) return new ImmutableResponseStatus(false, "repair argument was null.");
        if (repair.owner == null) return new ImmutableResponseStatus(false, "Owner for whom Property requested repair not set");
        if (repair.property == null) return new ImmutableResponseStatus(false, "Property field requesting repair not set");

        Owner? queryProperty = _repairApplicationDbContext.Owners.FirstOrDefault(o => o.VatNumber == repair.owner.VatNumber);
        Property? queryOwner = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == repair.property.PropertyID);

        if (queryProperty == null) return new ImmutableResponseStatus(false, "Property requesting repair is not registered.");
        if (queryOwner == null) return new ImmutableResponseStatus(false, "Property's Owner is not registered.");

        Repair? repairOwnerQueryResult = _repairApplicationDbContext.Repairs.FirstOrDefault(r => r.owner == queryProperty && r.property == queryOwner);
        if (repairOwnerQueryResult == null) return new ImmutableResponseStatus(false, "Repair not found in database.");

        repairOwnerQueryResult.PrintSelf();

        return new ImmutableResponseStatus(true, "Repair successfully displayed.");
    }


    public ImmutableResponseStatus UpdateRepairInfo(Repair repair){
        if (repair == null) return new ImmutableResponseStatus(false, "repair argument was null.");
        if (repair.owner == null) return new ImmutableResponseStatus(false, "Owner for whom Property requested repair not set");
        if (repair.property == null) return new ImmutableResponseStatus(false, "Property field requesting repair not set");

        Owner? queryOwner = _repairApplicationDbContext.Owners.FirstOrDefault(o => o.VatNumber == repair.owner.VatNumber);
        Property? queryProperty = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == repair.property.PropertyID);
        if (queryProperty == null) return new ImmutableResponseStatus(false, "Property requesting repair is not registered.");
        if (queryOwner == null) return new ImmutableResponseStatus(false, "Property's Owner is not registered.");

        Repair? repairOwnerQueryResult = _repairApplicationDbContext.Repairs.FirstOrDefault(r => r.owner == queryOwner && r.property == queryProperty);
        if (repairOwnerQueryResult == null) return new ImmutableResponseStatus(false, "Repair not found in database.");

        repairOwnerQueryResult.ScheduledRepairDate = repair.ScheduledRepairDate;
        repairOwnerQueryResult.Cost = repair.Cost;
        repairOwnerQueryResult.RType = repair.RType;
        repairOwnerQueryResult.Description = repair.Description;
        repairOwnerQueryResult.Status = repair.Status;
        _repairApplicationDbContext.SaveChanges();
        return new ImmutableResponseStatus(true, "Changes Updated Successfully.");
    }

    public ImmutableResponseStatus DeleteRepair(Repair repair){
        if (repair == null) return new ImmutableResponseStatus(false, "repair argument was null.");
        if (repair.owner == null) return new ImmutableResponseStatus(false, "Owner for whom Property requested repair not set");
        if (repair.property == null) return new ImmutableResponseStatus(false, "Property field requesting repair not set");

        Owner? queryOwner = _repairApplicationDbContext.Owners.FirstOrDefault(o => o.VatNumber == repair.owner.VatNumber);
        Property? queryProperty = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == repair.property.PropertyID);
        if (queryProperty == null) return new ImmutableResponseStatus(false, "Property requesting repair is not registered.");
        if (queryOwner == null) return new ImmutableResponseStatus(false, "Property's Owner is not registered.");

        Repair? repairOwnerQueryResult = _repairApplicationDbContext.Repairs.FirstOrDefault(r => r.owner == queryOwner && r.property == queryProperty);
        if (repairOwnerQueryResult == null) return new ImmutableResponseStatus(false, "Repair not found in database.");

        _repairApplicationDbContext.Repairs.Remove(repairOwnerQueryResult);
        _repairApplicationDbContext.SaveChanges();
        return new ImmutableResponseStatus(true, "Repair Removed");
    }
}
