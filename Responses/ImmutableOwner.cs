using TechnicoApplication.Models;

namespace TechnicoApplication.Responses;

public record ImmutableOwner(string Email,string Name,string Surname,string Address,string VatNumber,string PhoneNumber, string password, Owner.OwnerType ownerType);
