<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/smartphone0.jpg" 
        Height="562px" style="margin-bottom: 0px" />
  
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" >
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" >
    <div style="height: 380px">
    
        <asp:Label ID="Label1" runat="server" Text="ShoppingCart"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Welcome to LetShop.com"></asp:Label>
        &nbsp  &nbsp  &nbsp  &nbsp &nbsp  <asp:Label ID="Label6" runat="server" Text="No of Products in Your Cart :">
         </asp:Label>
        <asp:Label ID="Label7" runat="server" Text="Label" Font-Size="Large"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AddToCart.aspx">ShowCart</asp:HyperLink>

        <asp:DataList ID="DataList1" runat="server" BackColor="#DEBA84" 
            BorderColor="#DEBA84" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            CellSpacing="4" GridLines="Both" Width="439px" 
            RepeatDirection="Horizontal" Height="201px" 
            onitemcommand="DataList1_ItemCommand">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <ItemTemplate>
                <table class="style1" cellspacing="3">
                    <tr>
                        <td align="justify">
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("product_id") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="justify">
                           <asp:Label ID="Label5" runat="server" Text='<%#Eval("product_name") %>'></asp:Label>
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td>
                            <asp:Image ID="Image2" runat="server"  ImageUrl='<%#Eval("product_image") %>' />
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("product_price") %>' ></asp:Label>
                            &nbsp;</td>
                    </tr>

                     <tr>
                        <td>
                           Quantity: 
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Add to Cart" CommandName="addtoCart" CommandArgument='<%#Eval("product_id") %>' />
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Button ID="Button2" runat="server" Text="BuyNow" CommandName="BuyNow" CommandArgument='<%#Eval("product_id") %>' />
                            &nbsp;</td>
                    </tr>
                </table>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
    
    </div>
    </form>
</body>
</html>

</asp:Content>

