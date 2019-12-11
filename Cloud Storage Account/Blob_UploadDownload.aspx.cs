using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace Blob1
{
    public partial class Blob_UD : System.Web.UI.Page
    {
        CloudBlockBlob blob;
        protected void Page_Load(object sender, EventArgs e)
        {
            CloudStorageAccount sa = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("NDSACS"));
            CloudBlobClient client = sa.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference("images");
            container.CreateIfNotExists();
            blob = container.GetBlockBlobReference("logo");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            blob.UploadFromStream(File.OpenRead(@"D:\1.png"));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            blob.DownloadToStream(File.OpenWrite(@"D:\nd_1.png"));
        }
    }
}