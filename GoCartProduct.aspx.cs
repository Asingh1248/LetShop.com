using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;


public partial class GoCartProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MySqlConnection con;
        String myConnectionString;
        myConnectionString = "Server=localhost;Database=shoppingcart;Uid=root;password=12345;";
        con = new MySqlConnection(myConnectionString);
        Console.WriteLine("Connection is Opened");
        con.Open();

        string fetchdetails = "select p.product_name,p.product_descr,p.product_price,o.orderdate,o.orderno from product p,orders o where p.product_id=o.productid";
        //string fetchdetails1 = "select * from signup  where product_id=1";
        MySqlCommand cmd = new MySqlCommand(fetchdetails, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Label1.Text = dr[0].ToString();
            Label2.Text = dr[1].ToString();
            Label3.Text = dr[2].ToString();
            Label4.Text = dr[3].ToString();
            Label5.Text = dr[4].ToString();
            
        }

    }

    protected void Buy_Click(object sender, EventArgs e)
    {
        Response.Redirect("Buy.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["orderdate"] = Label4.Text;
        Session["price"] = Label3.Text;
        Session["product_desc"] = Label2.Text;
        Session["product_name"] = Label1.Text;
        Response.Redirect("Shopping_Cart.aspx");
    }
}