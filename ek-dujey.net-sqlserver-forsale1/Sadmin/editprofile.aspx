<%@ Page Language="VB" MasterPageFile="~/Sadmin/MasterPage.master" AutoEventWireup="false" CodeFile="editprofile.aspx.vb" Inherits="Sadmin_editprofile" title="Edit Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <table>
        <tr>
            <td>
                Username</td>
            <td>
                <asp:TextBox ID="txtusername" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Password</td>
            <td>
                <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Save" Width="110px" /></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
    </center>
</asp:Content>

