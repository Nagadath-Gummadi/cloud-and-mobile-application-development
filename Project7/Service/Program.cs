using System;
using System.Collections.Generic; using System.Linq;
using System.Text;
using System.Threading.Tasks; using System.ServiceModel; using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
TokenProvider token = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAcc essKey", "2geKYuIEGyHKeN4DiuGFDdHBe4Xc7vsVROJ2TVfe4hc=");
Uri path = ServiceBusEnvironment.CreateServiceUri("sb", "gsnaidu", String.Empty); NamespaceManager mgr = new NamespaceManager(path, token); if (!mgr.QueueExists("messaging"))
            {
                mgr.CreateQueue("messaging");
            }
MessagingFactory factory = MessagingFactory.Create(path, token);
QueueClient client = factory.CreateQueueClient("messaging"); BrokeredMessage msg = new BrokeredMessage(); msg.Properties.Add("Tid", "1000");
msg.Properties.Add("Tval", "220"); client.Send(msg); Console.WriteLine("Message Sent"); 
Console.Read();
        }
    }
}
