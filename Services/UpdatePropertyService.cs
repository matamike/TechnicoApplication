using TechnicoApplication.Models;
using TechnicoApplication.Responses;

namespace TechnicoApplication.Services;

public class UpdatePropertyService{
    public void UpdateProperty(Property property, Owner owner, ImmutableProperty newData){
        PropertyHandler.UpdateProperty(property, owner, newData);
    }
}
