using TechnicoApplication.Models;
using TechnicoApplication.Responses;

namespace TechnicoApplication.Services;

public static class OwnerHandler{

    private static Dictionary<string, Owner> Owners = new Dictionary<string, Owner>();

    private static void LoadOwners(){
        //this part will be loading from a DB instead.

        //TEMP SOLUTION (TESTING ONLY)
        Owner owner = new Owner()
        {
            VatNumber = "TY2000",
            Address = "NAM 12",
            Email = "kati@hah.com",
            Name = "Jenny",
            Password = "123",
            PhoneNumber = "0192837465",
            Surname = "Johnson",
            OType = Owner.OwnerType.Individual,
        };

        Owner owner2 = new Owner()
        {
            VatNumber = "XZ1996",
            Address = "XAS 12",
            Email = "kati2@hah.com",
            Name = "John",
            Password = "111",
            PhoneNumber = "0191037465",
            Surname = "Doe",
            OType = Owner.OwnerType.Individual,
        };

        Owner owner3 = new Owner()
        {
            VatNumber = "XZ1980",
            Address = "HAN 12",
            Email = "kati3@hah.com",
            Name = "Jack",
            Password = "OMG",
            PhoneNumber = "0198937465",
            Surname = "Smith",
            OType = Owner.OwnerType.Individual,
        };

        Owners.Add(owner.Email, owner);
        Owners.Add(owner2.Email, owner2);
        Owners.Add(owner3.Email, owner3);
        //TEMP SOLUTION (TESTING ONLY)
    }

    static OwnerHandler(){
        LoadOwners();
    }

    public static void CreateOwner(Owner owner){
        OwnerFieldValidation(out bool result, out string message, owner);
        if(result) Owners.Add(owner.Email, owner);
        Console.WriteLine(message);
    }

    public static void UpdateOwner(Owner owner, ImmutableOwner refreshedOwnerData){
        if (!OwnerExists(owner)){
            Console.WriteLine("No Owner found!");
            return;
        }
        Owners[owner.Email] = new Owner(){
            Address = refreshedOwnerData.Address,
            Name = refreshedOwnerData.Name,
            Surname = refreshedOwnerData.Surname,
            PhoneNumber = refreshedOwnerData.PhoneNumber,
            VatNumber = refreshedOwnerData.VatNumber,
            Email = refreshedOwnerData.Email,
            Password = refreshedOwnerData.password,
            OType = refreshedOwnerData.ownerType
        };
        Console.WriteLine($"Changes for Owner ({refreshedOwnerData.Email}) have been applied.");
    }

    public static void DisplayOwnerData(Owner source){
        string displayOwnerInfo = OwnerExists(source) ? GetOwnerDisplayData(source.Email) : "No Owner found!";
        Console.WriteLine(displayOwnerInfo);
    }

    public static void DeleteOwner(Owner source){
        if (!OwnerExists(source)){
            Console.WriteLine("No Owner found!");
            return;
        }

        Owners.Remove(source.Email);
        Console.WriteLine($"Owner ({source.Email}) has been removed.");
    }

    //Validation
    public static void OwnerFieldValidation(out bool result, out string message, Owner owner){
        result = true;
        message = "Registration Successful";

        if(owner == null){
            message = "<<<Null Owner instance>>>";
            result = false;
            return;
        }
        if (owner.Email == null){
            message = "<<<Null Email field>>>";
            result = false;
            return;
        }
        if (owner.Email == string.Empty){
            message = "<<<Empty Email field>>>";
            result = false;
            return;
        }
        if(owner.Password == null){
            message = "<<<Null Password field>>>";
            result = false;
            return;
        }
        if (owner.Password == string.Empty){
            message = "<<<Empty Password field>>>";
            result = false;
            return;
        }
        if (OwnerExists(owner)){
            message = $"User with {owner.Email} already exists.";
            result = false;
            return;
        }
    }
    public static bool OwnerExists(Owner owner){
        bool result = false;
        if(owner != null) {
            if (Owners.ContainsKey(owner.Email)) result = true;
        }
        return result;
    }

    public static string GetOwnerDisplayData(string email){
        if (Owners.ContainsKey(email)) {
            Owner currentOwner = Owners[email];
            return new ImmutableOwner(currentOwner.Email, currentOwner.Name, currentOwner.Surname, 
                                      currentOwner.Address, currentOwner.VatNumber,currentOwner.PhoneNumber, 
                                      currentOwner.Password, currentOwner.OType).ToString();
        }
        else return string.Empty;
    }
}
