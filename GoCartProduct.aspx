<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="GoCartProduct.aspx.cs" Inherits="GoCartProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Product">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/smartphone_1.PNG" />
        
        <br />
       
        <asp:Button ID="Buy" runat="server" Text="Buy" onclick="Buy_Click" />
        <br />
        <br />
        
             <h2> Product Description</h2>
   <table cellpadding="15px" cellspacing="50px" border="1">
    
    <tr>
      <td>
          
          <asp:Label ID="Label1" runat="server" Text=""></asp:Label> 
      </td>
      <td>
          <asp:Label ID="Label2" runat="server" Text=""></asp:Label> 
      </td>
      <td>
          <asp:Label ID="Label3" runat="server" Text=""></asp:Label> 
      </td>
      <td>
          <asp:Label ID="Label4" runat="server" Text=""></asp:Label> 
      </td>
      <td>
          <asp:Label ID="Label5" runat="server" Text=""></asp:Label> 
      </td>
     <%-- <td>
          <asp:Label ID="Label6" runat="server" Text=""></asp:Label> 
      </td>--%>
    </tr>
   </table>
    </div>
   </asp:Content>
