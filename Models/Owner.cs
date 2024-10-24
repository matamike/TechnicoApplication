namespace TechnicoApplication.Models.PropertyOwner;

public class Owner{
    public enum OwnerType{
        Individual,
        Business,
    }
    
    private string? _vatNumber;
    private string? _name;
    private string? _surname;
    private string? _address;
    private string? _phoneNumber;
    private string? _email;
    private string? _password;
    private OwnerType _ownerType;

}
