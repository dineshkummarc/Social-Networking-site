<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="members_login" title="Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table width="90%">
        <tr>
            <td>
            </td>
            <td align="left">
    <asp:Login ID="Login1" runat="server">
    </asp:Login>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/regi.aspx">Register if You dont have a Alc</asp:HyperLink><br />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <br />
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/forgotpass.aspx">if You Dont Remember Your Password Click Here</asp:HyperLink></td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    &nbsp;<br />
    <br />
    <br />
</asp:Content>

