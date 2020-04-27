using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
 TokenProvider token = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "H+rYJ3XugZAx4AwBWbgkgiqBzdxiFOY2ZR9FicPK840=");
            Uri path = ServiceBusEnvironment.CreateServiceUri("sb","ajaybus","");
            MessagingFactory factory = MessagingFactory.Create(path, token);
 MessageReceiver reciever = factory.CreateMessageReceiver("DetailmessageTopic/subscriptions/High");
            BrokeredMessage msg;
            while((msg=reciever.Receive())!=null)
            {
                Console.WriteLine("hello");
  Console.WriteLine("Message:" + msg.GetBody<String>()+"\t Priority:   "+msg.Properties["priority"]);
                msg.Complete();
            }
            Console.WriteLine("The High Priority Queue completed");
reciever = factory.CreateMessageReceiver("DetailmessageTopic/subscriptions/Low");
            while ((msg = reciever.Receive()) != null)
            {
                Console.WriteLine("hello");
  Console.WriteLine("Message:" + msg.GetBody<String>() + "\t Priority: " +     msg.Properties["priority"]);
                msg.Complete();
            }
            Console.WriteLine("The Low Priority Queue completed");
        }
    }
}
