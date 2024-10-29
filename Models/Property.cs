using System.ComponentModel.DataAnnotations;

namespace TechnicoApplication.Models;

public class Property : IPrintable {
    [Key] public int Id { get; private set; }
    public string? PropertyID { get; set; } = null;
    public string PropertyAddress { get; set; } = string.Empty;
    public int PropertyConstructionYear { get; set; }
    public PropertyType PType { get; set; }
    public Owner? owner { get; set; }

    public void PrintSelf() {
        Console.WriteLine($"====================== \n" +
                          $" Property ID: {PropertyID} \n" +
                          $" Property Address: {PropertyAddress} \n" +
                          $" Property ConstructionYear: {PropertyConstructionYear} \n" +
                          $" Property Type: {PType.ToString()} \n" +
                          $"====================== \n"); 
    }
}
