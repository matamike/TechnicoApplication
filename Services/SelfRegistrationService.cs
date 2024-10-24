using TechnicoApplication.Models;

namespace TechnicoApplication.Services;

public class SelfRegistrationService{
    public void RegisterOwner(Owner newOwner){
        OwnerHandler.CreateOwner(newOwner);
    }
}
