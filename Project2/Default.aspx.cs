using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace TableWebRole
{
    public class ContactEntity : TableEntity
    {
        public ContactEntity() { }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public ContactEntity(string fn, string ln, string cn, string ct)
        {
            FirstName = fn;
            LastName = ln;
            RowKey = cn;
            PartitionKey = ct;
        }
    }
    public partial class Default : System.Web.UI.Page
    {
        CloudTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            CloudStorageAccount sa = CloudStorageAccount.Parse(Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.GetConfigurationSettingValue("mycon"));
            CloudTableClient tc = sa.CreateCloudTableClient();
            table = tc.GetTableReference("contacts");
            table.CreateIfNotExists();
            TableQuery<ContactEntity> contactQuery = new TableQuery<ContactEntity>();
            contactsGrid.DataSource = table.ExecuteQuery(contactQuery);
            contactsGrid.DataBind();
        }

        protected void cmdInsert_Click(object sender, EventArgs e)
        {
            ContactEntity ce = new ContactEntity(txtFN.Text, txtLN.Text, txtCN.Text, lstCT.SelectedValue);
            TableOperation insertop = TableOperation.Insert(ce);
            table.Execute(insertop);
            Response.Redirect("Default.aspx");
        }

        protected void contactsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            insertTable.Visible = false;
            contactsGrid.Visible = false;
            Editfs.Visible = true;
            int index = Int32.Parse(e.CommandArgument.ToString());
            GridViewRow SelectedRow = contactsGrid.Rows[index];
            txtefn.Text = SelectedRow.Cells[0].Text;
            txteln.Text = SelectedRow.Cells[1].Text;
            txtecn.Text = SelectedRow.Cells[2].Text;
            txtect.Text = SelectedRow.Cells[3].Text;
        }

        protected void cmdub_Click(object sender, EventArgs e)
        {
            TableOperation replaceop = TableOperation.Retrieve<ContactEntity>(txtect.Text, txtecn.Text);
            TableResult result = table.Execute(replaceop);
            ContactEntity updateEntity = (ContactEntity)result.Result;
            updateEntity.FirstName = txtefn.Text;
            updateEntity.LastName = txteln.Text;
            table.Execute(TableOperation.InsertOrReplace(updateEntity));
            Response.Redirect("Default.aspx");

        }

        protected void cmddb_Click(object sender, EventArgs e)
        {
            TableOperation retrieveOp = TableOperation.Retrieve<ContactEntity>(txtect.Text, txtecn.Text);
            TableResult result = table.Execute(retrieveOp);
            ContactEntity deleteEntity = (ContactEntity)result.Result;
            table.Execute(TableOperation.Delete(deleteEntity));
            Response.Redirect("Default.aspx");
        }
    }
}
