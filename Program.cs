// See https://aka.ms/new-console-template for more information
using TechnicoApplication.Models;

Console.WriteLine("Welcome To Technico!");
Console.WriteLine("A repair Management Project.");

//Create DB Context

//Start Services 


///==================PROPERTIES=========================///
Owner currentOwner = new Owner()
{
    VatNumber = "405060",
    Email = "omgYEAH@aol.com",
    Password = "1234567890",
    Name = "Nick",
    Surname = "Johnson",
};

Owner currentOwner2 = new Owner()
{
    VatNumber = "149567",
    Email = "omgLOL@gmail.com",
    Password = "1444567890",
    Name = "Josh",
    Surname = "Morris",
};

Property property1 = new()
{
    PropertyID = "34",
    PropertyAddress = "Willis St. 029",
    OwnerVatNumber = currentOwner.VatNumber,
    PropertyConstructionYear = 1998,
};

Property property2 = new()
{
    PropertyID = "49",
    PropertyAddress = "Rodston Ave 108",
    OwnerVatNumber = currentOwner2.VatNumber,
    PropertyConstructionYear = 2003,
};







