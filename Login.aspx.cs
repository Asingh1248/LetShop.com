using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Menu MyMasterMenu = (Menu)Master.FindControl("Menu1");
        MyMasterMenu.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MySqlConnection con; 
        String myConnectionString;
        myConnectionString = "Server=localhost;Database=shoppingcart;Uid=root;password=12345;"; 
        con = new MySqlConnection(myConnectionString); 
        Console.WriteLine("Connection is Opened"); 
        con.Open();

        string email = TextBox1.Text; 
        string password = TextBox2.Text;
        
        
        string loginq = "select * from signup where email='" + email + "' and password='" + password + "'";
        MySqlCommand cmd = new MySqlCommand(loginq, con);
        MySqlDataReader reader = cmd.ExecuteReader();  
        //int count = int.Parse(reader);  
        if (reader.Read())
        {
            //Label3.Text = "Login Successfull";
            Session["email"] = email;
            Response.Redirect("Default.aspx");
        }  else  
        { 
           
            Label3.Text = "kindly Enter the email and password correctly";  
        }    
        con.Close(); 

    }
}