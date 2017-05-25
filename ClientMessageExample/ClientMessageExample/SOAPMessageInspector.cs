using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace ClientMessageExample
{
    public class SOAPMessageInspector : IClientMessageInspector
    {
        public string ResponseXml { get; set; }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            //throw new NotImplementedException();
            ResponseXml = reply.ToString();
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            
            //throw new NotImplementedException();
        }
    }
}
