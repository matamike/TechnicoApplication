using TechnicoApplication.Models;

namespace TechnicoApplication.Services;

public class DeletePropertyService{
    public void DeleteProperty(Property property, Owner owner){
        PropertyHandler.DeleteProperty(property, owner);
    }
}
