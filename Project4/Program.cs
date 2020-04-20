using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace Default
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = "ndazuresqlserver.database.windows.net";
            csb.InitialCatalog = "ndsqlserver";
            csb.UserID = "nagadath";
            csb.Password = "server@1234";
            SqlConnection con = new SqlConnection(csb.ConnectionString);
            SqlCommand cmd = new SqlCommand("create table tab21(RgNo varchar(25),Name varchar(30) NOT NULL,Branch varchar(30) primary key(RgNo))", con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table is Successfully Created");
            cmd.CommandText = "insert into tab21 values('Y17ACS445','Nagadath','CSE')";
            if (cmd.ExecuteNonQuery() == 1)
                Console.WriteLine("First Row is Inserted");
            else
                Console.WriteLine("Error");
            cmd.CommandText = "insert into tab21 values('Y17ACS439','Prasanth','CSE')";
            if (cmd.ExecuteNonQuery() == 1)
                Console.WriteLine("Second Row is Inserted");
            else
                Console.WriteLine("Error");
            cmd.CommandText = "select * from tab21";
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine(sdr[0] + "\t" + sdr[1] + "\t" + sdr[2]);
            }
            sdr.Close();
            cmd.CommandText = "drop table tab21";
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table deleted sucessfully");
            con.Close();
            Console.ReadLine();
        }
    }
}



