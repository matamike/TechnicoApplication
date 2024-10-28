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
RepairService repairService = new RepairService(repairApplicationDbContext);

Owner owner = new Owner(){
    Name = "John",
    Surname = "Wick",
    VatNumber = "L1C3NC3D_K1LL3R",
    OType = OwnerType.Individual,
    Address = "Something 13",
    Email = "John.Wick@aol.com",
    Password = "1234567890",
    PhoneNumber = "3016875",
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

Repair repair = new Repair()
{
    Description = "Plumbing broken. Requires indoor override.",
    owner = owner,
    property = property,
    RType = RepairType.Plumbing,
    Cost = 2000.0m,
    ScheduledRepairDate = DateTime.Today.AddDays(10), //normally this should be set by the company assigned the repair request (after estimation)
};

//repairService.RegisterRepair(repair);
//repairService.DeleteRepair(repair);
//repairService.UpdateRepairInfo(repair);
//repairService.SearchRepair(repair);










