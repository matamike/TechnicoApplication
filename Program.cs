// See https://aka.ms/new-console-template for more information
using TechnicoApplication.Models;
using TechnicoApplication.Repositories;
using TechnicoApplication.Services;

Console.WriteLine("Welcome To Technico!");
Console.WriteLine("A repair Management Project.");

//Create DB Context
RepairApplicationDbContext repairApplicationDbContext = new RepairApplicationDbContext();

//Start Services 
OwnerService ownerService = new OwnerService(repairApplicationDbContext);

Owner owner = new Owner()
{
    Name = "John",
    Surname = "Wick",
    VatNumber = "L1C3NC3D_K1LL3R",
    OType = OwnerType.Individual,
    Address = "Something 13",
    Email = "John.Wick@aol.com",
    Password = "1234567890",
    PhoneNumber = "3016875",
};

ownerService.RegisterOwner(owner);

owner.Name = "Agent";
owner.Surname = "47";
owner.Email = "Agent.47@aol.com";
ownerService.UpdateOwnerInfo(owner);

ownerService.DisplayOwnerInfo(owner);
//ownerService.DeleteOwner(owner);









