<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="reflink.aspx.vb" Inherits="members_reflink" title="Referal Links" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="90%">
        <tr>
            <td align="left">
            </td>
            <td id="TD1" runat="server" align="left">
            </td>
        </tr>
        <tr>
            <td>
                Your Referal Link</td>
            <td align="left">
                <asp:TextBox ID="txtreflink" runat="server" Width="571px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                email Content<br />
                Copy and Paste Content and Send Email To Your Friends</td>
            <td align="left">
                <asp:TextBox ID="TextBox1" runat="server" Height="228px" TextMode="MultiLine" Width="561px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

