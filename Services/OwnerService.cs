using TechnicoApplication.Models;
using TechnicoApplication.Repositories;
using TechnicoApplication.Responses;

namespace TechnicoApplication.Services;

public class OwnerService{
    private RepairApplicationDbContext _repairApplicationDbContext;
    public OwnerService(RepairApplicationDbContext repairApplicationDbContext) => _repairApplicationDbContext = repairApplicationDbContext;

    public ImmutableResponseStatus RegisterOwner(Owner owner){
        if (owner is null) return new ImmutableResponseStatus(false, "owner argument is null.");

        Owner? ownerVatQueryResult = _repairApplicationDbContext.Owners.FirstOrDefault(c => c.VatNumber == owner.VatNumber);
        Owner? ownerEmailQueryResultt = _repairApplicationDbContext.Owners.FirstOrDefault(c => c.Email == owner.Email);
        if (ownerVatQueryResult != null) return new ImmutableResponseStatus(false, "Owner registration with the VatNumber provided already exists.");

        if (ownerEmailQueryResultt != null) return new ImmutableResponseStatus(false, "Owner registration with the Email provided already exists.");

        if (owner.Email == null || owner.Email == string.Empty) return new ImmutableResponseStatus(false, "Owner input email is null or empty");

        if (owner.VatNumber == null || owner.VatNumber == string.Empty) return new ImmutableResponseStatus(false, "Owner input VatNumber is null or empty");

        _repairApplicationDbContext.Owners.Add(owner);
        _repairApplicationDbContext.SaveChanges();

        return new ImmutableResponseStatus(true, "Owned Registered", owner);
    }

    public ImmutableResponseStatus DisplayOwnerInfo(Owner owner){
        if (owner is null) return new ImmutableResponseStatus(false, "owner argument is null.");

        Owner? ownerQueryResult = _repairApplicationDbContext.Owners.FirstOrDefault(c => c.VatNumber == owner.VatNumber);
        if (ownerQueryResult == null) return new ImmutableResponseStatus(false, "owner argument is null.");

        ownerQueryResult.PrintSelf();

        Console.WriteLine("===========PROPERTIES===========");
        _repairApplicationDbContext.Properties.Select(p => p)
                                              .Where(p => p.owner == ownerQueryResult)
                                              .ToList()
                                              .ForEach(res => res.PrintSelf());
        Console.WriteLine("================================");

        Console.WriteLine("===========REPAIRS===========");
        _repairApplicationDbContext.Repairs.Select(r => r)
                                      .Where(r => r.owner == ownerQueryResult)
                                      .ToList()
                                      .ForEach(res => res.PrintSelf());
        Console.WriteLine("=============================");

        return new ImmutableResponseStatus(true, "Owned Data successfully displayed");
    }

    public ImmutableResponseStatus UpdateOwnerInfo(Owner owner){
        if (owner is null) return new ImmutableResponseStatus(false, "owner argument is null.");

        Owner? ownerQueryResult = _repairApplicationDbContext.Owners.FirstOrDefault(c => c.VatNumber == owner.VatNumber);
        if (ownerQueryResult == null) return new ImmutableResponseStatus(false, "Owner requested update changes does not exist");

        if (ownerQueryResult.VatNumber != owner.VatNumber) return new ImmutableResponseStatus(false, "Detected Change(VAT). Changing Owner's VAT is not allowed.");

        if (ownerQueryResult.Email != owner.Email) return new ImmutableResponseStatus(false, "Detected Change(Email). Changing Owner's Email is not allowed.");

        ownerQueryResult.Name = owner.Name;
        ownerQueryResult.Surname = owner.Surname;
        ownerQueryResult.Address = owner.Address;
        ownerQueryResult.PhoneNumber = owner.PhoneNumber;
        _repairApplicationDbContext.SaveChanges();
        return new ImmutableResponseStatus(true, "Changes Updated Successfully.", ownerQueryResult);
    }

    public ImmutableResponseStatus DeleteOwner(Owner owner){
        if (owner is null) return new ImmutableResponseStatus(false, "owner argument is null.");

        Owner? ownerQueryResult = _repairApplicationDbContext.Owners.FirstOrDefault(c => c.VatNumber == owner.VatNumber);
        if (ownerQueryResult == null) return new ImmutableResponseStatus(false, "Owner requested removal does not exist");

        //Delete owner from the db.
        _repairApplicationDbContext.Owners.Remove(ownerQueryResult);
        _repairApplicationDbContext.SaveChanges();
        return new ImmutableResponseStatus(true, "Owner Removed", owner);
    }
}
