<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="inviteafriend.aspx.vb" Inherits="members_inviteafriend" title="Invite Friends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <table>
        <tr>
            <td align="left" valign="top">
                Email Address<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtemail" Display="Dynamic" ErrorMessage="Email Address Required"
                    SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            <td align="left" valign="top">
                <asp:TextBox ID="txtemail" runat="server" Width="332px"></asp:TextBox> of Your Friend</td>
        </tr>
        <tr>
            <td align="left" valign="top">
                Message
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail"
                    Display="Dynamic" ErrorMessage="Check Email Address, only 1 Email Address" SetFocusOnError="True"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            <td align="left" valign="top">
            <div id="dd" runat="server" style="text-align: left; border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid;">xsdfsafsdf</div>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
            </td>
            <td align="left" valign="top">
                <asp:Button ID="Button1" runat="server" Text="Go Ahead Invite Your Friend" />
                
                </td>
        </tr>
        <tr>
            <td align="left" style="height: 21px" valign="top">
            </td>
            <td align="left" style="height: 21px" valign="top">
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
    </center>
</asp:Content>

