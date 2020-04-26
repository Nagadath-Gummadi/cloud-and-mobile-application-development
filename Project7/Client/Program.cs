using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
           Uri serviceUri = ServiceBusEnvironment.CreateServiceUri("sb", "ndservice", String.Empty);
           TokenProvider credentials = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAcc essKey", "2geKYuIEGyHKeN4DiuGFDdHBe4Xc7vsVROJ2TVfe4hc="); MessagingFactory factory = MessagingFactory.Create(serviceUri, credentials); QueueClient client = factory.CreateQueueClient("messaging");
           BrokeredMessage msg = client.Receive();
           Console.WriteLine("TID:" + msg.Properties["Tid"] + "\t Tval:" +      msg.Properties["Tval"]);
           Console.Read();
           msg.Complete();
        }
    }
}

