<%@ Page Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false" CodeFile="contactus.aspx.vb" Inherits="contactus" title="Contact Us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%  If Not Page.IsPostBack Then%>
    <table border="1">
        <tr>
            <td style="width: 100px">
                Name</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Email</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 24px;">
                Subject</td>
            <td style="width: 100px; height: 24px;">
                <asp:TextBox ID="txtsubject" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Comments</td>
            <td style="width: 100px">
            <textarea id="txtcomments" cols="30" rows="10" runat="server"></textarea>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="lblstatus" runat="server"></asp:Label></td>
            <td style="width: 100px">
                <asp:Button ID="Button1" runat="server" Text="Send" /></td>
        </tr>
    </table>
    <%end if %>
    
</asp:Content>

