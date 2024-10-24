using TechnicoApplication.Models;
using TechnicoApplication.Responses;

namespace TechnicoApplication.Services;

public class DisplayOwnerService{

    public void DisplayUserInfo(Owner targetOwner){
        DisplayOwnerInfo(targetOwner);

        //TODO LATER
        //retrieve property info (owner) -- Callback in References from Owner Properties saved in another Service Handler
        //retrieve repair info (owner)  -- Callback in References from Owner Properties saved in another Service Handler
    }

    private void DisplayOwnerInfo(Owner targetOwner){
        OwnerHandler.DisplayOwnerData(targetOwner);
    }

    public void UpdateUserInfo(Owner targetOwner, ImmutableOwner newData){
        OwnerHandler.UpdateOwner(targetOwner, newData);
    }

    public void DeleteUserInfo(Owner targetOwner){
        OwnerHandler.DeleteOwner(targetOwner);
    }


}
