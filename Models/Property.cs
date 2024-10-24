namespace TechnicoApplication.Models;

public class Property{
    public enum PropertyType{
        DetachedHouse,
        Maisonet,
        ApartmentBuilding,
    }

    public string? PropertyID { get; set; } = string.Empty;
    public string? PropertyAddress { get; set; } = string.Empty;
    public int PropertyConstructionYear { get; set; }
    public string? OwnerVatNumber { get; set; } = string.Empty; //makes more sense to use Owner instead (it looks like a foreign key to Owner Entity)
}
