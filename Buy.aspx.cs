using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

public partial class Buy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MySqlConnection con;
        String myConnectionString;
        myConnectionString = "Server=localhost;Database=shoppingcart;Uid=root;password=12345;";
        con = new MySqlConnection(myConnectionString);
        Console.WriteLine("Connection is Opened");
        con.Open();

        string fetchdetails = "select * from product where product_id=1";
        MySqlCommand cmd = new MySqlCommand(fetchdetails, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Label1.Text = dr["product_name"].ToString();
            Label2.Text = dr["product_descr"].ToString();
            Label3.Text = dr["product_price"].ToString();
            Label4.Text = dr["product_id"].ToString();

        }

    }
}