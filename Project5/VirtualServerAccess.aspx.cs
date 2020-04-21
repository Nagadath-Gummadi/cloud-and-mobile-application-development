using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VirtualSqlServer
{
    public partial class VirtualSqlServerAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdinsert_Click(object sender, EventArgs e)
        {
            string insertquery = "insert into student values('"+txtname.Text+"','"+txtregno.Text+"','"+ddlsection.SelectedItem.Value+"')";
            string cs=ConfigurationManager.ConnectionStrings["tempConnectionString"].ConnectionString;
            SqlConnection con=new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(insertquery,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("VirtualSqlServerAccess.aspx");

        }
    }
}

