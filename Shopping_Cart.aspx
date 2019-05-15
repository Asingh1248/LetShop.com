<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Shopping_Cart.aspx.cs" Inherits="Shopping_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div>
       <table border="2" align="center" width="50%">
        <tr>
          <th><h2>Cart Details</h2></th>
        </tr>
          <tr>
            <td> 
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td> 
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td> 
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label> </td>
          </tr>
         
       </table>
   </div>

</asp:Content>

