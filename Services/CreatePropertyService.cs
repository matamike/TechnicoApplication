using TechnicoApplication.Models;

namespace TechnicoApplication.Services;

public class CreatePropertyService{

    public void CreateProperty(Property property, Owner owner){
        PropertyHandler.CreateProperty(property, owner);
    }
}
