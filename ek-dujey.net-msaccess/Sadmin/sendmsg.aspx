<%@ Page Language="VB" MasterPageFile="~/Sadmin/MasterPage.master" AutoEventWireup="false" CodeFile="sendmsg.aspx.vb" Inherits="Sadmin_sendmsg" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label><table>
        <tr>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox1" runat="server" Columns="50" MaxLength="2000" Rows="10"
                    TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Button ID="Button1" runat="server" Text="Send Message" Width="132px" /></td>
        </tr>
    </table>
    </center>
</asp:Content>

