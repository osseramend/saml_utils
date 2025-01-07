using OutSystems.ExternalLibraries.SDK;
using System.Security.Cryptography;
using System.Text;

namespace SAMLHelper
{
    [OSInterface(Description = "SAML 2.0 Authentication Helper utility library")]
    public interface ISAMLHelper
    {
        [OSAction(Description = "Get the Authorization Request for SAML authentication", ReturnName = "Url", ReturnDescription = "Redirect URL for Authentication")]
        public string GetSAMLAuthRequestUrl(
            [OSParameter(Description ="SSO Endpoint for authentication")]
            string SamlEndpoint,
            [OSParameter(Description ="SAML Issuer for authentication")]
            string Issuer,
            [OSParameter(Description ="SAML authentication redirect URL")]
            string RedirectUrl,
            [OSParameter(Description ="RelayState for response identification")]
            string RelayState = "");

        [OSAction(Description = "Get information from the SAML authentication response", ReturnName = "Result", ReturnDescription = "SAMl Response processing result")]
        public SAMLProcessingResponse ProcessSAMLAuthResponse(
            [OSParameter(Description ="SAML Certificate to decode response")]
            string samlCertificate,
            [OSParameter(Description ="SAML Response")]
            string samlResponse,
            [OSParameter(Description ="List of Optional Attributes to obtain from the SAML Response")]
            List<string>? optionalAttributesNames = null);

        [OSAction(Description = "Get the Signout Request for SAML Signout", ReturnName = "Url", ReturnDescription = "Redirect URL for SignOut")]
        public string GetSAMLSignOutURL(
            [OSParameter(Description ="SSO Endpoint for signout")]
            string samlEndpoint,
            [OSParameter(Description ="SAML Issuer for signout")]
            string issuer,
            [OSParameter(Description ="NameId for the resource to Signout")]
            string nameId,
            [OSParameter(Description ="RelayState for response identification")]
            string relayState = "");

        [OSAction(Description = "Get information from the SAML signout response", ReturnName = "Result", ReturnDescription = "SAMl Singout Response processing result")]
        public SAMLSignoutResponse ProcessSAMLSignOutResponse(
            [OSParameter(Description ="SAML Certificate to decode response")]
            byte[] samlCertificate,
            [OSParameter(Description ="SAML Response")]
            string samlResponse);

        [OSAction(Description = "Get a SHA256 hash from a string", ReturnName = "Result", ReturnDescription = "SAMl Singout Response processing result")]
        public string GetSHA256Hash(string input);
    }


}
