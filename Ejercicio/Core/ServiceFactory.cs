using System.ServiceModel;
using System.ServiceModel.Description;

namespace Core
{
    public class ServiceFactory : IServiceFactory
    {
        public CurrencyConvertorSoap Create()
        {            
            var endPointAddress = new EndpointAddress("http://www.webservicex.net/CurrencyConvertor.asmx?wsdl");
            var binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

            CurrencyConvertorSoapClient claseProxy = new CurrencyConvertorSoapClient(binding, endPointAddress);
            claseProxy.Endpoint.EndpointBehaviors.Add(new SOAPMessageInspector());

            ClientCredentials loginCredentials = new ClientCredentials();
            
            loginCredentials.UserName.UserName = "myusername";
            loginCredentials.UserName.Password = "mypassword";

            claseProxy.Endpoint.EndpointBehaviors.Add(loginCredentials);

            return claseProxy;
        }
    }
}
