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
PropertyService propertyService = new PropertyService(repairApplicationDbContext);

Owner owner = new Owner()
{
    Name = "Donald",
    Surname = "McDonald",
    VatNumber = "HAHA349",
    OType = OwnerType.Individual,
    Address = "Clown 158",
    Email = "Donald.McDonald@omg.com",
    Password = "131313131",
    PhoneNumber = "999555010",
};

//ownerService.RegisterOwner(owner);

//owner.Name = "Agent";
//owner.Surname = "47";
//owner.Email = "Agent.47@aol.com";
//ownerService.UpdateOwnerInfo(owner);

//ownerService.DisplayOwnerInfo(owner);
//ownerService.DeleteOwner(owner);


//Property Test
//Property property = new Property()
//{
//    owner = owner,
//    PropertyAddress = "Somewhere 185",
//    PropertyConstructionYear = 1999,
//    PropertyID = "SHWWRA78",
//    PType = PropertyType.Maisonet,
//};
Property property = new Property()
{
    owner = owner,
    PropertyAddress = "Harold 10",
    PropertyConstructionYear = 2020,
    PropertyID = "SHWWRA78",
    PType = PropertyType.DetachedHouse,
};

//propertyService.RegisterProperty(property);
//propertyService.DisplayPropertyInfo(property);
//propertyService.DeleteProperty(property);

//propertyService.UpdatePropertyInfo(property);











