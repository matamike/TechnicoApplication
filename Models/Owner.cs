using System.ComponentModel.DataAnnotations;

namespace TechnicoApplication.Models;

public class Owner{
    [Key] public int Id { get; private set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string? Email { get; set; } = null;
    public string Password { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? VatNumber { get; set; } = null;
    public string PhoneNumber { get; set; } = string.Empty;
    public OwnerType OType { get; set; }
}
