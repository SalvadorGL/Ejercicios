using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class SOAPMessageInspector : IClientMessageInspector, IEndpointBehavior
    {
        public string RequestXML { get; set; }
        public string ResponseXML { get; set; }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            //throw new NotImplementedException();
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            log4net.log.Info("AfterReceiveReply: " + reply.ToString());
            ResponseXML = reply.ToString();
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(this);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            //throw new NotImplementedException();
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            log4net.log.Info("BeforeSendRequest" + request.ToString());
            RequestXML = request.ToString();
            HttpRequestMessageProperty httpRequestMessage = new HttpRequestMessageProperty();
            httpRequestMessage.Headers.Add("MyHeaderElement", "MyValue");
            //request.Properties.Add()
            return request;
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            //throw new NotImplementedException();
        }
    }
}
