<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Buy.aspx.cs" Inherits="Buy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div>
       <table border="1" align="center" width="50%">
        <tr>
          <th><h2>Order Details</h2></th>
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
           <tr>
            <td align="center">
                    <asp:Button ID="Button1" runat="server" Text="PayNow" BorderColor="#66CCFF" /> </td>
          </tr>
         
       </table>
   </div>
</asp:Content>

