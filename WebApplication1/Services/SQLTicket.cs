using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    public class SQLTicket
    {
        public static string GetRoleUser(string Name)
        {
            string con_string = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=NSSPIDemo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlcon = new SqlConnection(con_string);
            sqlcon.Open();
            string query = "select * from Users where PrincipalName ='" + Name + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            string Role = "";
            if (dtbl.Rows.Count == 1)
            {
                Role = dtbl.Rows[0][2].ToString();
            }
            return Role;
        }
    }
}