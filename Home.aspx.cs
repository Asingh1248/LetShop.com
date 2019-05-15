using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

public partial class Home: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)Session["buyitems"];
        if (dt != null)
        {
            Label7.Text = dt.Rows.Count.ToString();
        }

        else
        {
            Label7.Text = "0";
        }


        if (!IsPostBack)
        {
            BindDataList();
        }
    }

    private void BindDataList()
    {
        MySqlConnection con;
        String myConnectionString;
        myConnectionString = "Server=localhost;Database=shoppingcart;Uid=root;password=12345;";
        con = new MySqlConnection(myConnectionString);
        Console.WriteLine("Connection is Opened");
        con.Open();
        string fetchproduct = "select * from product";
        MySqlCommand cmd = new MySqlCommand(fetchproduct, con);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        DataList1.DataSource = dt;
        DataList1.DataBind();
        con.Close();

    }

    //Select List --AddEvent--Items
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        //Vishal Concept of the Button se Command
        if (e.CommandName == "addtoCart")
        {

            DropDownList dlist = (DropDownList)(e.Item.FindControl("DropDownList1"));
            Response.Redirect("AddtoCart.aspx?id=" + e.CommandArgument.ToString() + "&quantity=" + dlist.SelectedItem.ToString());

            //CommandName="addtoCart" CommandArgument='<%#Eval("product_id") %>'
        }
        else if (e.CommandName == "BuyNow")
        {
            DropDownList dlist = (DropDownList)(e.Item.FindControl("DropDownList1"));
            Response.Redirect("GoCartProduct.aspx?id=" + e.CommandArgument.ToString() + "&quantity=" + dlist.SelectedItem.ToString());
         
        }
    }
}