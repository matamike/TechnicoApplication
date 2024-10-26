using TechnicoApplication.Models;

namespace TechnicoApplication.Services;
public class PropertyService{

    public void RegisterProperty(Property property){
        //Register Property (given that Owner exists in the Owners table)
        //and property is not already registered.
    }

    public void DisplayPropertyInfo(Property property){
        //Display a specific property's information (if registered)
    }


    public void UpdatePropertyInfo(Property property){
        //if the property exists in the db and we are the owner
        //we are allowed to update anything (even changing owner) -> (VAT) -> has to be registered in the Owners DB in order to be valid change.
        
    }

    public void DeleteProperty(Property property){
        //when we delete a property we need to make sure it exists in the db
        //and we are the owner of the property.
    }
}

