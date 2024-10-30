// See https://aka.ms/new-console-template for more information
using TechnicoApplication.Models;
using TechnicoApplication.Repositories;
using TechnicoApplication.Responses;
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
    Surname = "Winston",
    VatNumber = "T3X4S_W4RR10R",
    OType = OwnerType.Individual,
    Address = "Howdy 13",
    Email = "John.Winston@aol.com",
    Password = "2312312312",
    PhoneNumber = "2828347237",
};

ImmutableResponseStatus response =  ownerService.Create(owner);
Console.WriteLine(response.ToString());

//owner.Name = "Agent";
//owner.Surname = "47";
//owner.Email = "Agent.47@aol.com";
//ownerService.UpdateOwnerInfo(owner);

//ownerService.Display(owner);
//ownerService.Delete(owner);


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
    PropertyAddress = "Treisson 27",
    PropertyConstructionYear = 2004,
    PropertyID = "FSDFFASDF22",
    PType = PropertyType.Maisonet,
};

ImmutableResponseStatus propertyResponse = propertyService.Create(property);
Console.WriteLine(propertyResponse.ToString());

//propertyService.Display(property);
//propertyService.Delete(property);
//propertyService.Update(property);

Repair repair = new Repair()
{
    Description = "Plumbing broken. Requires indoor override.",
    owner = owner,
    property = property,
    RType = RepairType.Plumbing,
    Cost = 2000.0m,
    ScheduledRepairDate = DateTime.Today.AddDays(10), //normally this should be set by the company assigned the repair request (after estimation)
};

//repairService.Create(repair);
//repairService.Delete(repair);
//repairService.Update(repair);
//repairService.Display(repair);










