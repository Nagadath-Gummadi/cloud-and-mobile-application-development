using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
 TokenProvider token = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "H+rYJ3XugZAx4AwBWbgkgiqBzdxiFOY2ZR9FicPK840=");
            Uri path = ServiceBusEnvironment.CreateServiceUri("sb", "ajaybus", "");
            NamespaceManager mgr = new NamespaceManager(path, token);
            if(!mgr.TopicExists("DetailmessageTopic"))
            {
                mgr.CreateTopic("DetailmessageTopic");
            }
            Console.WriteLine("Topic Created");
            if (mgr.SubscriptionExists("DetailmessageTopic", "High"))
            {
                mgr.DeleteSubscription("DetailmessageTopic", "High");
            }
            SqlFilter filter = new SqlFilter("Priority>2");
            mgr.CreateSubscription("DetailmessageTopic", "High", filter);
            Console.WriteLine("The High Subscription is created");
            if (mgr.SubscriptionExists("DetailmessageTopic", "Low"))
            {

                mgr.DeleteSubscription("DetailmessageTopic", "Low");
            }
            filter = new SqlFilter("Priority<=2");
            mgr.CreateSubscription("DetailmessageTopic", "Low", filter);
            Console.WriteLine("The low Subscription created");
            MessagingFactory factory = MessagingFactory.Create(path, token);
            TopicClient client = factory.CreateTopicClient("DetailmessageTopic");
            for(int i=0;i<=5;i++)
            {
                BrokeredMessage msg = new BrokeredMessage("message:" +i);
                msg.Properties.Add("priority", i);
                client.Send(msg);
            }
            Console.Read();
        }
    }
}




