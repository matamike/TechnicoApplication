using TechnicoApplication.Models;
using TechnicoApplication.Repositories;

namespace TechnicoApplication.Services;
public class PropertyService{
    private RepairApplicationDbContext _repairApplicationDbContext;
    public PropertyService(RepairApplicationDbContext repairApplicationDbContext) => _repairApplicationDbContext = repairApplicationDbContext;

    public void RegisterProperty(Property property){
        if(property == null){
            Console.WriteLine("property argument was null.");
            return;
        }

        if (property.PropertyID == null || property.PropertyID == string.Empty)
        {
            Console.WriteLine("PropertyID not set");
            return;
        }

        if (property.owner == null){
            Console.WriteLine("Property Owner not set");
            return;
        }
        
        Property? queryProperty = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == property.PropertyID);
        if (queryProperty != null){
            Console.WriteLine($"Property with PropertyID: {queryProperty.PropertyID} already exists.");
            return;
        }

        Owner? queryOwner = _repairApplicationDbContext.Owners.FirstOrDefault(p => p.VatNumber == property.owner.VatNumber);
        if (queryOwner == null){
            Console.WriteLine("Property's Owner is not registered.");
            return;
        }


        //Register Property
        property.owner = queryOwner;
        _repairApplicationDbContext.Properties.Add(property);
        _repairApplicationDbContext.SaveChanges();
        Console.WriteLine("Property Registered");
    }

    public void DisplayPropertyInfo(Property property){
        if (property == null){
            Console.WriteLine("property argument was null.");
            return;
        }

        Property? propertyQuery = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == property.PropertyID);
        if (propertyQuery == null){
            Console.WriteLine("Property requested to be displayed cannot be found.");
            return;
        }

        Console.WriteLine("===================================");
        Console.WriteLine($" PropertyID: {propertyQuery.PropertyID} \n" +
                  $" Address: {propertyQuery.PropertyAddress} \n" +
                  $" Construction Year:{propertyQuery.PropertyConstructionYear} \n" +
                  $" Property Type: {propertyQuery.PType.ToString()} \n");
        Console.WriteLine("===================================");
    }

    public void UpdatePropertyInfo(Property property){
        if (property is null){
            Console.WriteLine("property argument is null.");
            return;
        }

        Property? propertyQueryResult = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == property.PropertyID);
        if (propertyQueryResult == null){
            Console.WriteLine($"Property requested update changes does not exist");
            return;
        }

        if(property.owner == null){
            Console.WriteLine("Property argument has owner null.");
            return;
        }

        Owner? targetQueryOwner = _repairApplicationDbContext.Owners.FirstOrDefault(p => p.VatNumber == property.owner.VatNumber);
        if (targetQueryOwner == null){
            Console.WriteLine("Owner requested change does not exist in database. ");
            return;
        }

        propertyQueryResult.PropertyAddress = property.PropertyAddress;
        propertyQueryResult.PropertyConstructionYear = property.PropertyConstructionYear;
        propertyQueryResult.owner = targetQueryOwner;
        _repairApplicationDbContext.SaveChanges();
        Console.WriteLine("Changes Updated Successfully.");
    }

    public void DeleteProperty(Property property){
        if (property == null){
            Console.WriteLine("property argument was null.");
            return;
        }

        Property? propertyQueryResult = _repairApplicationDbContext.Properties.FirstOrDefault(p => p.PropertyID == property.PropertyID);
        if (propertyQueryResult == null){
            Console.WriteLine("Property requested removal does not exist.");
            return;
        }

        _repairApplicationDbContext.Properties.Remove(propertyQueryResult);
        _repairApplicationDbContext.SaveChanges();
        Console.WriteLine("Property Removed");
    }
}

