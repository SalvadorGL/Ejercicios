using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Core
{
    public class SOAPMessageInspector : IClientMessageInspector, IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            Log4net.Log.Info("AfterReceiveReply: " + reply.ToString());
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(this);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            Log4net.Log.Info("BeforeSendRequest" + request.ToString());
            HttpRequestMessageProperty httpRequestMessage = new HttpRequestMessageProperty();
            httpRequestMessage.Headers.Add("MyHeaderElement", "MyValue");
            request.Properties.Add("MyName", httpRequestMessage);
            
            return request;
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}
