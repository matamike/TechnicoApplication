using System.ComponentModel.DataAnnotations;

namespace TechnicoApplication.Models;

public class Owner : IPrintable{
    [Key] public int Id { get; private set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string? Email { get; set; } = null;
    public string Password { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? VatNumber { get; set; } = null;
    public string PhoneNumber { get; set; } = string.Empty;
    public OwnerType OType { get; set; }

    public void PrintSelf(){
        Console.WriteLine($"====================== \n" +
                  $" Name: {Name} \n" +
                  $" Surname: {Surname} \n" +
                  $" Email:{Email} \n" +
                  $" Address: {Address} \n" +
                  $" VAT: {VatNumber} \n" +
                  $" PhoneNumber: {PhoneNumber} \n" +
                  $"====================== \n");
    }

}
