// See https://aka.ms/new-console-template for more information
using TechnicoApplication.Models;
using TechnicoApplication.Responses;
using TechnicoApplication.Services;

Console.WriteLine("Welcome To Technico!");
Console.WriteLine("A repair Management Project.");

//Start Services 
SelfRegistrationService selfRegistrationService = new SelfRegistrationService();
DisplayOwnerService displayOwnerService = new DisplayOwnerService();

//Owner currentOwner = new Owner()
//{
//    VatNumber = "mm1990kati",
//    Email = "omgYEAH@hah.com",
//    Password = "1234567890",
//    Name = "Totos",
//    Surname = "Johnson",
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







