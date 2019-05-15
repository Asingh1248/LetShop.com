<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddtoCart.aspx.cs" Inherits="AddtoCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" >
    <title></title>
</head>
<body>
    <form id="form1" >
    <div>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="LetsShop.com"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Size="X-Large" 
            Text="You have added the Product to the Cart"></asp:Label>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Continue Shopping</asp:HyperLink>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" ForeColor="Black" GridLines="Vertical" Height="225px" 
            ShowFooter="True" onrowdeleting="GridView1_RowDeleting" 
            HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="sno" HeaderText="S.No" />
                <asp:BoundField DataField="product_id" HeaderText="ProductId" />
                <asp:BoundField DataField="product_name" HeaderText="ProductName" />
                <asp:BoundField DataField="product_price" HeaderText="Price" />
                <asp:BoundField DataField="discount" HeaderText="Discount" NullDisplayText="10%" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="totalprice" HeaderText="TotalPrice" />
                <asp:BoundField DataField="product_descr" HeaderText="ProductDescription" />
                <asp:ImageField DataImageUrlField="product_image" HeaderText="ProductImage">
                    
                    
                    <ItemStyle HorizontalAlign="Center" />
                </asp:ImageField>
               <%-- <asp:HyperLinkField HeaderText="Remove" Text="Remove" NavigateUrl="AddtoCart.aspx" />--%>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Clear all" 
            onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>


</asp:Content>

