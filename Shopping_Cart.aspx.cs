using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shopping_Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Text = "Product Name :"+Session["product_name"].ToString();
        Label2.Text = "Product Description: " +Session["product_desc"].ToString();
        Label3.Text = "Product Price: "+Session["price"].ToString();
        //Label4.Text = "Order Date: " + Session["orderdate"].ToString();
        Label1.Text = "Username:  " +Session["email"].ToString();
   }

}