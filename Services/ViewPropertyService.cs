using TechnicoApplication.Models;

namespace TechnicoApplication.Services;

public class ViewPropertyService{

    public void ViewProperty(Property property, Owner owner){
        PropertyHandler.ViewProperty(property, owner);
    }
}
