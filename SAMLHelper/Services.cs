using Saml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SAMLHelper
{
    public class SAMLHelper : ISAMLHelper
    {
        public string GetSAMLAuthRequestUrl(string samlEndpoint, string issuer, string redirectUrl, string relayState = "")
        {
            var samlRequest = new AuthRequest(issuer, redirectUrl);
            return samlRequest.GetRedirectUrl(samlEndpoint, relayState);
        }

        public SAMLProcessingResponse ProcessSAMLAuthResponse(string samlCertificate, string samlResponse, List<string>? optionalAttributesNames = null)
        {
            var result = new SAMLProcessingResponse();
            Response samlResponseInstance = new Response(samlCertificate, samlResponse);
            result.IsValid = samlResponseInstance.IsValid();
            if (result.IsValid)
                {
                result.User = new UserInformation {
                    Company = samlResponseInstance.GetCompany(),
                    Department = samlResponseInstance.GetDepartment(),
                    Email = samlResponseInstance.GetEmail(),
                    FirstName = samlResponseInstance.GetFirstName(),
                    LastName = samlResponseInstance.GetLastName(),
                    Location = samlResponseInstance.GetLocation(),
                    NameId = samlResponseInstance.GetNameID(),
                    Phone = samlResponseInstance.GetPhone(),
                    Upn = samlResponseInstance.GetUpn(),
                    CustomAttributes = new List<CustomAttribute>(),
                };
                if (optionalAttributesNames != null && optionalAttributesNames.Any())
                {

                    foreach (var attributeName in optionalAttributesNames)
                    {
                        result.User.CustomAttributes.Add(new CustomAttribute { Name = attributeName, Value = samlResponseInstance.GetCustomAttribute(attributeName) });
                    }
                }
            }
            return result;
        }

        public string GetSAMLSignOutURL(string samlEndpoint, string issuer, string nameId, string relayState = "")
        {
            var signoutReq = new SignoutRequest(issuer, nameId);
            return signoutReq.GetRedirectUrl(samlEndpoint, relayState);
        }

        public SAMLSignoutResponse ProcessSAMLSignOutResponse(byte[] samlCertificate, string samlResponse)
        {
            SAMLSignoutResponse result = new SAMLSignoutResponse();
            var signoutResp = new SignoutResponse(samlCertificate, samlResponse);
            result.IsValid = signoutResp.IsValid();

            return result;
        }
        public string GetSHA256Hash(string input)
        {
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }

    }
}
