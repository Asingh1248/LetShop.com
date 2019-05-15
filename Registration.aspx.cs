using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient; //MySQl Net ..dll browse using System.Data.SqlClient; 


public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Menu MyMasterMenu = (Menu)Master.FindControl("Menu1");
        MyMasterMenu.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {  //Connection con1 = new Connection();  //con1.Connect(); 
        MySqlConnection con; 
        String myConnectionString;
        myConnectionString = "Server=localhost;Database=shoppingcart;Uid=root;password=12345;"; 
        con = new MySqlConnection(myConnectionString); 
        Console.WriteLine("Coonection is Opened");
        con.Open(); 

        string fname, lname, email, password, phoneno; 
        fname = TextBox1.Text; 
        lname = TextBox2.Text; 
        email = TextBox3.Text; 
        password = TextBox5.Text;
        phoneno = TextBox4.Text; 
        string insertq = "insert into signup(fname,lname,email,password,phone) values ('" + fname + "','" + lname + "','" + email + "','" + password + "','" + phoneno + "')  "; 
        MySqlCommand cmd = new MySqlCommand(insertq, con); 
        cmd.ExecuteNonQuery();
        Label6.Text = "Registration Succesfully";
        con.Close();
        Response.Redirect("Login.aspx");


    }
}

