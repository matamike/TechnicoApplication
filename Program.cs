// See https://aka.ms/new-console-template for more information
using TechnicoApplication.Models;
using TechnicoApplication.Responses;
using TechnicoApplication.Services;

Console.WriteLine("Welcome To Technico!");
Console.WriteLine("A repair Management Project.");

//Start Services 
SelfRegistrationService selfRegistrationService = new SelfRegistrationService();
DisplayOwnerService displayOwnerService = new DisplayOwnerService();
CreatePropertyService createPropertyService = new CreatePropertyService();
ViewPropertyService viewPropertyService = new ViewPropertyService();
DeletePropertyService deletePropertyService = new DeletePropertyService();
UpdatePropertyService updatePropertyService = new UpdatePropertyService();

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

selfRegistrationService.RegisterOwner(currentOwner);//OK - Test
selfRegistrationService.RegisterOwner(currentOwner2);//OK - Test

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

createPropertyService.CreateProperty(property1, currentOwner);//OK - Test
createPropertyService.CreateProperty(property2, currentOwner2);//OK - Test

viewPropertyService.ViewProperty(property1, currentOwner);
//ImmutableProperty newPropertyData = new ImmutableProperty("204", "Marlon 63", currentOwner2.VatNumber, property1.PropertyConstructionYear);
//updatePropertyService.UpdateProperty(property1, currentOwner, newPropertyData); //bugs when
viewPropertyService.ViewProperty(property2, currentOwner2);

//viewPropertyService.ViewProperty(property2, currentOwner); //OK - Test
//viewPropertyService.ViewProperty(null, currentOwner); //OK - Test
//viewPropertyService.ViewProperty(property1, currentOwner2); //OK - Test

//deletePropertyService.DeleteProperty(property1, currentOwner); //OK - Test
//deletePropertyService.DeleteProperty(null, currentOwner); //OK - Test
//deletePropertyService.DeleteProperty(property1, null); //OK - Test
//deletePropertyService.DeleteProperty(property1, currentOwner2); //OK - Test



///==================OWNERS=========================///
//Owner currentOwner3 = new Owner()
//{
//    VatNumber = "mm1990kati",
//    Email = "HelloLara@lara.com",
//    Password = "1299567890",
//    Name = "Lara",
//    Surname = "Winston",
//};

//Register
//selfRegistrationService.RegisterOwner(null); //(OK)
//selfRegistrationService.RegisterOwner(currentOwner); //(OK)

//Display
//displayOwnerService.DisplayUserInfo(null); //(OK)
//displayOwnerService.DisplayUserInfo(currentOwner); //(OK)

//Delete
//displayOwnerService.DeleteUserInfo(currentOwner); //(OK)
//displayOwnerService.DeleteUserInfo(null); //(OK)


//ImmutableOwner newData = new ImmutableOwner("", "", "", "", "", "", "", Owner.OwnerType.Individual);

//Update
//displayOwnerService.UpdateUserInfo(currentOwner, newData); //(OK)
//displayOwnerService.UpdateUserInfo(null, newData); // (OK)







