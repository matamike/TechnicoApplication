using TechnicoApplication.Models;
using TechnicoApplication.Repositories;
using TechnicoApplication.Responses;

namespace TechnicoApplication.Services;
public class PropertyService : ICRUDService<Property>{
    private RepairApplicationDbContext _repairApplicationDbContext;
    public PropertyService(RepairApplicationDbContext repairApplicationDbContext) => _repairApplicationDbContext = repairApplicationDbContext;

    public ImmutableResponseStatus Create(Property property){
        if (property == null) return new ImmutableResponseStatus(false, "property argument was null.");

        if (property.PropertyID == null || property.PropertyID == string.Empty) return new ImmutableResponseStatus(false, "PropertyID not set");

        if (property.owner == null) return new ImmutableResponseStatus(false, "Property Owner not set");
        
        Property? queryProperty = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == property.PropertyID);
        if (queryProperty != null) return new ImmutableResponseStatus(false, $"Property with PropertyID: {queryProperty.PropertyID} already exists.");

        Owner? queryOwner = _repairApplicationDbContext.Owners.FirstOrDefault(p => p.VatNumber == property.owner.VatNumber);
        if (queryOwner == null) return new ImmutableResponseStatus(false, "Property's Owner is not registered.");

        property.owner = queryOwner;
        _repairApplicationDbContext.Properties.Add(property);
        _repairApplicationDbContext.SaveChanges();
        return new ImmutableResponseStatus(true, "Property Registered", property);
    }

    public ImmutableResponseStatus Display(Property property){
        if (property == null) return new ImmutableResponseStatus(false, "property argument was null.");

        Property? propertyQuery = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == property.PropertyID);
        if (propertyQuery == null) return new ImmutableResponseStatus(false, "Property requested to be displayed cannot be found.");
        Console.WriteLine(propertyQuery.ToString());
        return new ImmutableResponseStatus(true, "Property Data successfully displayed");
    }

    public ImmutableResponseStatus Update(Property property){
        if (property == null) return new ImmutableResponseStatus(false, "property argument was null.");

        if (property.owner == null) return new ImmutableResponseStatus(false, "Property argument has input owner null.");

        Property? propertyQuery = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == property.PropertyID);
        if (propertyQuery == null) return new ImmutableResponseStatus(false, "Property requested update changes does not exist");

        Owner? targetQueryOwner = _repairApplicationDbContext.Owners.FirstOrDefault(p => p.VatNumber == property.owner.VatNumber);
        if (targetQueryOwner == null) return new ImmutableResponseStatus(false, "Owner requested change not registered.");

        propertyQuery.PropertyAddress = property.PropertyAddress;
        propertyQuery.PropertyConstructionYear = property.PropertyConstructionYear;
        propertyQuery.owner = targetQueryOwner;
        _repairApplicationDbContext.SaveChanges();
        return new ImmutableResponseStatus(true, "Changes Updated Successfully.", propertyQuery);
    }

    public ImmutableResponseStatus Delete(Property property){
        if (property == null) return new ImmutableResponseStatus(false, "property argument was null.");

        Property? propertyQuery = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == property.PropertyID);
        if (propertyQuery == null) return new ImmutableResponseStatus(false, "Property requested removal does not exist.");

        _repairApplicationDbContext.Properties.Remove(propertyQuery);
        _repairApplicationDbContext.SaveChanges();
        return new ImmutableResponseStatus(true, "Property Removed");
    }
}

