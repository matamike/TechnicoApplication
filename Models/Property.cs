namespace TechnicoApplication.Models;

public class Property{
    public string PropertyID { get; set; } = string.Empty;
    public string PropertyAddress { get; set; } = string.Empty;
    public int PropertyConstructionYear { get; set; }
    public Owner? owner { get; set; }
    public PropertyType PType { get; set; }
}
