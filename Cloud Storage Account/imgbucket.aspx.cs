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
    public partial class imgbucket : System.Web.UI.Page
    {
    
        CloudBlobContainer container;
        protected void Page_Load(object sender, EventArgs e)
        {
            CloudStorageAccount sa = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("NDSACS"));
            CloudBlobClient client = sa.CreateCloudBlobClient();
          container = client.GetContainerReference("photobucket");
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            imagegrid.DataSource = container.ListBlobs();
            imagegrid.DataBind();

           
        }

        protected void cmduploadbtn_Click(object sender, EventArgs e)
        {
            CloudBlockBlob blob = container.GetBlockBlobReference(imageselector.FileName);
            blob.UploadFromStream(imageselector.FileContent);
            Response.Redirect("imgbucket.aspx");
        }
    }
}