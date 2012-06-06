<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="members_login" title="Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Login ID="Login1" runat="server">
    </asp:Login>
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/regi.aspx">Register if You dont have a Alc</asp:HyperLink><br />
    <br />
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/forgotpass.aspx">if You Dont Remember Your Password Click Here</asp:HyperLink>
</asp:Content>

