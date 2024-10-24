namespace TechnicoApplication.Models.PropertyItem;

public class Property{
    public enum PropertyType{
        DetachedHouse,
        Maisonet,
        ApartmentBuilding,
    }

    private string? _propertyID;
    private string? _propertyAddress;
    private int _propertyConstructionYear;
    private string? _ownerVatNumber;
}
