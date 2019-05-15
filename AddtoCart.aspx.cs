using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using ServiceReference1;

public partial class AddtoCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            DataRow dr;

            //Adding Column to the DataTable
            dt.Columns.Add("sno");    //Header Set karne ke liye
            dt.Columns.Add("product_id");
            dt.Columns.Add("product_name");
            dt.Columns.Add("quantity");  //
            dt.Columns.Add("product_price");//
            dt.Columns.Add("discount");
            dt.Columns.Add("totalprice");//
            dt.Columns.Add("product_descr");
            dt.Columns.Add("product_image");


            if (Request.QueryString["id"] != null) //productid pass hua //sometimes only show karte no click on button
            {
                if (Session["Buyitems"] == null) //agar koi 1st row ..refer last line
                {
                    dr = dt.NewRow(); //2nd row pe jaane ke liye
                    MySqlConnection con;
                    String myConnectionString;
                    myConnectionString = "Server=localhost;Database=shoppingcart;Uid=root;password=12345;password=12345;";
                    con = new MySqlConnection(myConnectionString);
                    Console.WriteLine("Connection is Opened");
                    con.Open();
                    string myquery = "select * from product where product_id=" + Request.QueryString["id"];
                    MySqlCommand cmd = new MySqlCommand(myquery, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dr["sno"] = 1; //2nd(kyuki 1st row header) row pe sno--Column Created par --1
                    dr["product_id"] = ds.Tables[0].Rows[0]["product_id"].ToString();

                    dr["product_name"] = ds.Tables[0].Rows[0]["product_name"].ToString();
                    dr["product_price"] = ds.Tables[0].Rows[0]["product_price"].ToString();
                    WebService service = new WebService();

                    double priced = service.getDisc(Convert.ToInt32(ds.Tables[0].Rows[0]["product_price"]), 10);

                    dr["product_price"] = priced.ToString();
                    dr["quantity"] = Request.QueryString["quantity"];
                    dr["product_descr"] = ds.Tables[0].Rows[0]["product_descr"].ToString();
                    dr["product_image"] = ds.Tables[0].Rows[0]["product_image"].ToString();


                    //****
                    try
                    {
                        int price = Convert.ToInt16(ds.Tables[0].Rows[0]["product_price"].ToString());
                        int quantity = Convert.ToInt16(Request.QueryString["quantity"].ToString());
                        double totalprice = priced * quantity;
                        dr["totalprice"] = totalprice;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                    dt.Rows.Add(dr); //datatable 2nd row added

                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    Session["buyitems"] = dt;
                    GridView1.FooterRow.Cells[5].Text = "Total Amount"; //1st product whole details in session
                    GridView1.FooterRow.Cells[6].Text = grandtotal().ToString(); //
                    Response.Redirect("AddToCart.aspx");
                }
                else
                {
                    dt = (DataTable)Session["buyitems"]; //again 1st product details dala datatable me
                    int sr;
                    sr = dt.Rows.Count;  //act like counter
                    dr = dt.NewRow();  //3rd row added

                    MySqlConnection con;
                    String myConnectionString;
                    myConnectionString = "Server=localhost;Database=shoppingcart;Uid=root;password=12345;";
                    con = new MySqlConnection(myConnectionString);
                    Console.WriteLine("Connection is Opened");
                    con.Open();


                    string myquery = "select * from product where product_id=" + Request.QueryString["id"];
                    MySqlCommand cmd = new MySqlCommand(myquery, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dr["sno"] = sr + 1; //2nd
                    dr["product_id"] = ds.Tables[0].Rows[0]["product_id"].ToString();

                    dr["product_name"] = ds.Tables[0].Rows[0]["product_name"].ToString();
                    dr["product_price"] = ds.Tables[0].Rows[0]["product_price"].ToString();
                    WebService service = new WebService();

                    double priced = service.getDisc(Convert.ToInt32(ds.Tables[0].Rows[0]["product_price"]), 10);

                    dr["product_price"] = priced.ToString();
                    dr["product_descr"] = ds.Tables[0].Rows[0]["product_descr"].ToString();
                    dr["product_image"] = ds.Tables[0].Rows[0]["product_image"].ToString();

                    dr["quantity"] = Request.QueryString["quantity"];

                    try
                    {
                        int price = Convert.ToInt16
                         (ds.Tables[0].Rows[0]["product_price"].ToString());
                        int quantity = Convert.ToInt16(Request.QueryString["quantity"].ToString());
                        double totalprice = priced * quantity;
                        dr["totalprice"] = totalprice;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    

                    dt.Rows.Add(dr);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    Session["buyitems"] = dt; //Har Click pe kaam karega
                    GridView1.FooterRow.Cells[5].Text = "Total Amount";
                    GridView1.FooterRow.Cells[6].Text = grandtotal().ToString();
                    Response.Redirect("AddToCart.aspx");

                } //Session Handling if(null)..else(not null)
            } //RequestQery !=null
            else
            {

                //show cart(aab sab kuch session me store hai --dt)
                dt = (DataTable)Session["buyitems"]; //else(not null) first line
                GridView1.DataSource = dt;
                GridView1.DataBind();
                if (GridView1.Rows.Count > 0)
                {
                    GridView1.FooterRow.Cells[5].Text = "Total Amount";
                    int grandtotal1 = grandtotal();
                    GridView1.FooterRow.Cells[6].Text = grandtotal1.ToString();

                }
                Label2.Text += GridView1.Rows.Count.ToString();
            }
            //RequestQery (==null)

        }   //If Postback
    }   //:Load    

      public int grandtotal()
    {
        DataTable dt = new DataTable();
        dt = (DataTable)Session["buyitems"];
        int gtotal = 0;
        try
        {
            
        int nrow = dt.Rows.Count;


        
            int i = 0;
            
            while (i < nrow)
            {
                //Label3.Text = " SASDSA " + i;
                gtotal = gtotal + Convert.ToInt32(dt.Rows[i]["totalprice"].ToString());
                //Label3.Text = " SASDSA " + gtotal;
                i = i + 1;
                //Label3.Text = " SASDSA " + i;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return gtotal; 
      }



      protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
      {
        DataTable dt = new DataTable();
        dt = (DataTable)Session["buyitems"];
           

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            int sr;
            int sr1;
            
            string qdata;
            string dtdata;
            sr = Convert.ToInt32(dt.Rows[i]["sno"].ToString());
            Label3.Text = sr.ToString();
            TableCell cell = GridView1.Rows[e.RowIndex].Cells[0];
            
            qdata = cell.Text ;
            dtdata = sr.ToString();
            sr1 = Convert.ToInt32(qdata);

            if (sr == sr1)
            {
                dt.Rows[i].Delete();
                dt.AcceptChanges();
                //Label1.Text = "Item Has Been Deleted From Shopping Cart";
                break;

            }
        }

        for (int i = 1; i <= dt.Rows.Count; i++)
        {
            dt.Rows[i - 1]["sno"] = i;
            dt.AcceptChanges();
        }

        Session["buyitems"] = dt;
        Response.Redirect("AddToCart.aspx");
    }
      protected void Button1_Click(object sender, EventArgs e)
      {
          DataTable dt = new DataTable();
          dt = (DataTable)Session["buyitems"];
          GridView1.DataSource = dt;
          dt.Clear();
          GridView1.DataBind();
          
      
      }
}


//if(Click on the Button--RequestQueryString hai na)
// (if Yes(i.e not null))
// { 
//       checked(Session null (Connection--dr[Rows]0))-->(fill Session)
//else  
// {
//  dt fill ---Connectiondr[Rows]0 --Fill Session)
// }
//.........{
//last check for ConnectionQuery No QueryString   
// tab --already jo Query String Store hai usse use karo}

