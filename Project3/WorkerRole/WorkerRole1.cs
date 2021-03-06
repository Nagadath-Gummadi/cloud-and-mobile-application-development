using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Net.Mail;

namespace WorkerRole1
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        public override void Run()
        {
            CloudStorageAccount csa = CloudStorageAccount.Parse("UseDevelopmentStorage=true");
            CloudQueueClient client = csa.CreateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference("mail");
            queue.CreateIfNotExists();
            CloudQueueMessage msg = queue.GetMessage();
            if (msg != null)
            {
                String smsg = msg.AsString;
                String[] details = smsg.Split(',');
                SmtpClient sclient = new SmtpClient();
                sclient.Host = "smtp.gmail.com";
                sclient.Port = 587;
                sclient.UseDefaultCredentials = false;
                sclient.EnableSsl = true;
                MailMessage mmsg = new MailMessage();
                mmsg.From = new MailAddress("ayyappagolla@gmail.com");
                mmsg.To.Add(details[0]);
                mmsg.Subject = details[1];
                mmsg.Body = details[2];
                sclient.Credentials = new NetworkCredential("ayyappagolla@gmail.com", "A13189131");
                sclient.Send(mmsg);
                queue.DeleteMessage(msg);
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();

            Trace.TraceInformation("WorkerRole1 has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WorkerRole1 is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("WorkerRole1 has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
                await Task.Delay(1000);
            }
        }
    }
}

