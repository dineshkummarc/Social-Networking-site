<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="privacysettings.aspx.vb" Inherits="members_privacysettings" title="Privacy Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="width: 100px">
                Visibility</td>
            <td style="width: 100px">
                <asp:CheckBox ID="chkvisibleall" runat="server" Text="Visible to All (Even Un Registered Members)" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Password Protect Photo</td>
            <td style="width: 100px">
                <asp:CheckBox ID="chkphotpassword" runat="server" AutoPostBack="True" />
                <asp:TextBox ID="txtphotopassword" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:Button ID="Button1" runat="server" Text="Save" /></td>
        </tr>
    </table>
    <asp:Label ID="Label1" runat="server" ForeColor="Blue"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" ForeColor="Blue"></asp:Label><br />
</asp:Content>

