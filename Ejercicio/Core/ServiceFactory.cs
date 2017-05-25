using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ServiceFactory : IServiceFactory
    {
        public CurrencyConvertorSoap Create()
        {            
            var endPointAddress = new EndpointAddress("http://www.webservicex.net/CurrencyConvertor.asmx?wsdl");
            var binding = new BasicHttpBinding();
            CurrencyConvertorSoapClient claseProxy = new CurrencyConvertorSoapClient(binding, endPointAddress);

            claseProxy.Endpoint.EndpointBehaviors.Add(new SOAPMessageInspector());

            return claseProxy;
        }
    }
}
