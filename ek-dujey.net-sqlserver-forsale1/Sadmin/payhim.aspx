<%@ Page Language="VB" MasterPageFile="~/Sadmin/MasterPage.master" AutoEventWireup="false" CodeFile="payhim.aspx.vb" Inherits="Sadmin_payhim" title="Pay Him" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                Payment Number</td>
            <td style="width: 169px">
                <asp:TextBox ID="txtpaymentnumber" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Amount Pending</td>
            <td style="width: 169px">
                <asp:TextBox ID="txtamt" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Amount Paid</td>
            <td style="width: 169px">
                <asp:TextBox ID="txtamtpaid" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Pid</td>
            <td style="width: 169px">
                <asp:TextBox ID="txtpid" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Approval Id</td>
            <td style="width: 169px">
                <asp:TextBox ID="txtapproveid" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 169px">
                <asp:Button ID="Button1" runat="server" Text="Pay" Width="166px" /></td>
        </tr>
    </table>
</asp:Content>

