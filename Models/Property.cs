using System.ComponentModel.DataAnnotations;

namespace TechnicoApplication.Models;

public class Property{
    [Key] public int Id { get; private set; }
    public string PropertyID { get; set; } = string.Empty;
    public string PropertyAddress { get; set; } = string.Empty;
    public int PropertyConstructionYear { get; set; }
    public PropertyType PType { get; set; }
    public Owner? owner { get; set; }
}
