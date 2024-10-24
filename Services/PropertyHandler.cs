using TechnicoApplication.Models;
using TechnicoApplication.Responses;

namespace TechnicoApplication.Services
{
    public static class PropertyHandler{
        private static Dictionary<string, Property> Properties = new Dictionary<string, Property>();

        private static  void LoadProperties(){
            //load the properties registered from Database (TODO)
        }

        static PropertyHandler(){
            LoadProperties();
        }

        public static void CreateProperty(Property property, Owner owner){
            PropertyFieldValidation(out bool result, out string message, property);
            if (result){
                if (PropertyHasOwner(owner)){
                    Properties.Add(property.PropertyID, property);
                }
                else
                {
                    message = "Unregistered owner attempting to add Property. Please register and try again.";
                }

            }
            Console.WriteLine(message);
        }

        //BUG HERE (If we change the Vat of the dictionary, we don't change the local input property and therefore we are able to access the other data.
        public static void ViewProperty(Property property, Owner owner){
            if (owner == null) {
                Console.WriteLine("Property owner is null.");
                return;
            }
            string displayPropertyInfo = PropertyExists(property) ? GetPropertyDisplayData(property.PropertyID) : "No Property found!";

            
            if (property.OwnerVatNumber != owner.VatNumber){ 

                displayPropertyInfo = "Invalid Property Owner Input";
            }
            Console.WriteLine(displayPropertyInfo);
        }

        public static void DeleteProperty(Property property, Owner owner){
            if (!PropertyExists(property) || !OwnerHandler.OwnerExists(owner)){
                Console.WriteLine("Owner or Property does not exist.");
                return;
            }

            if (property.OwnerVatNumber != owner.VatNumber){
                Console.WriteLine("Invalid owner requesting deletion of Property");
                return;
            }

            Properties.Remove(property.PropertyID);
            Console.WriteLine($"Property with ID: ({property.PropertyID}) has been removed.");
        }

        public static void UpdateProperty(Property property, Owner owner, ImmutableProperty refreshedPropertyData)
        {
            if (!PropertyExists(property) || !OwnerHandler.OwnerExists(owner)){
                Console.WriteLine("No Property or Owner found!");
                return;
            }

            if (property.OwnerVatNumber != owner.VatNumber){
                Console.WriteLine("Invalid owner requesting deletion of Property");
                return;
            }

            Properties[property.PropertyID] = new Property()
            {
                PropertyID = refreshedPropertyData.PropertyID,
                OwnerVatNumber = refreshedPropertyData.OwnerVatNumber,
                PropertyAddress = refreshedPropertyData.PropertyAddress,
                PropertyConstructionYear = refreshedPropertyData.PropertyConstructionYear,
            };
            Console.WriteLine($"Changes for Property with ID ({refreshedPropertyData.PropertyID}) have been applied.");
        }

        //Validation
        public static void PropertyFieldValidation(out bool result, out string message, Property property)
        {
            result = true;
            message = "Property Registration Successful";

            if (property == null)
            {
                message = "<<<Null Property instance>>>";
                result = false;
                return;
            }
            if (property.PropertyID == null)
            {
                message = "<<<Null PropertyID field>>>";
                result = false;
                return;
            }
            if (property.PropertyID == string.Empty)
            {
                message = "<<<Empty PropertyID field>>>";
                result = false;
                return;
            }
            if (property.OwnerVatNumber == null)
            {
                message = "<<<Null OwnerVatNumber field>>>";
                result = false;
                return;
            }
            if (property.OwnerVatNumber == string.Empty)
            {
                message = "<<<Empty OwnerVatNumber field>>>";
                result = false;
                return;
            }

            if (property.PropertyAddress == null)
            {
                message = "<<<Null PropertyAddress field>>>";
                result = false;
                return;
            }
            if (property.PropertyAddress == string.Empty)
            {
                message = "<<<Empty PropertyAddress field>>>";
                result = false;
                return;
            }


            if (PropertyExists(property)){
                message = $"Property with {property.PropertyID} already exists.";
                result = false;
                return;
            }
        }

        public static bool PropertyExists(Property property)
        {
            bool result = false;
            if (property != null){
                result = Properties.ContainsKey(property.PropertyID);
            }
            return result;
        }

        public static bool PropertyHasOwner(Owner owner){
            bool result = false;
            if (owner != null){
                result = OwnerHandler.OwnerExists(owner);
            }
            return result;
        }

        public static string GetPropertyDisplayData(string propertyID){
            if (Properties.ContainsKey(propertyID)){
                Property currentProperty = Properties[propertyID];
                return new ImmutableProperty(currentProperty.PropertyID, currentProperty.PropertyAddress, 
                                             currentProperty.OwnerVatNumber, currentProperty.PropertyConstructionYear).ToString();
            }
            else return string.Empty;
        }

    }
}
