using OutSystems.ExternalLibraries.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMLHelper
{
    [OSStructure(Description = "SAML Response Information", OriginalName = "SAMLProcessingResponse")]
    public struct SAMLProcessingResponse
    {
        public UserInformation User;
        public bool IsValid;
    }



    [OSStructure(Description = "User Information from SAML", OriginalName = "UserInformation")]
    public struct UserInformation
    {
        public string Upn;
        public string NameId;
        public string FirstName;
        public string LastName;
        public string Email;
        public string Company;
        public string Department;
        public string Location;
        public string Phone;
        public List<CustomAttribute> CustomAttributes;
    }

    [OSStructure(Description = "Custom Attribute Information from SAML", OriginalName = "CustomAttribute")]
    public struct CustomAttribute
    {
        public string Name;
        public string Value;
    }

    [OSStructure(Description = "SAML Signout Response", OriginalName = "SAMLSignoutResponse")]
    public struct SAMLSignoutResponse
    {
        public bool IsValid;
    }

}
