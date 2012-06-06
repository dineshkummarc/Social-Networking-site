<%@ Page Language="VB" MasterPageFile="~/Sadmin/MasterPage.master" AutoEventWireup="false" CodeFile="websitesettings.aspx.vb" Inherits="Sadmin_websitesettings" title="Untitled Page" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="width: 100px">
                Website Name(without http://www" just website name`</td>
            <td style="width: 239px">
                <asp:TextBox ID="txtWebsiteName" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="width: 100px">
                Email Server<br />
                (Ask Your Host About it)</td>
            <td style="width: 239px">
                <asp:TextBox ID="txtemailserver" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Email Port</td>
            <td style="width: 239px">
                <asp:TextBox ID="txtemailport" runat="server" MaxLength="2">25</asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Auto Approve Profiles</td>
            <td style="width: 239px">
                <asp:DropDownList ID="dpautoaprove" runat="server">
                    <asp:ListItem Value="N">No</asp:ListItem>
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Date Format</td>
            <td style="width: 239px">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="he-IL">DD/MM/YYYY</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 130px">
                Google Adcode<br />
                <asp:Label ID="lblstatus" runat="server"></asp:Label><br />
                For the Main Default Page on the Right Side<br />
                <br />
                Please Check The Default Page<br />
                Only<br />
                <br />
                <strong>Vertical Banner (120 x 240)</strong></td>
            <td style="width: 239px; height: 130px">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Sadmin/120x240.gif" />
                Only This Type of Adcode Here
                <asp:TextBox ID="txtadcode1" runat="server" Columns="50"  Rows="10" TextMode="MultiLine"
                    ></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 130px">
                For the Entire Website<br />
                <strong>Leaderboard (728 x 90) Adcode here</strong></td>
            <td style="width: 239px; height: 130px">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Sadmin/leaderboard.gif" /><br />
                <asp:TextBox ID="txtadcode2" runat="server" Columns="50" Rows="10" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 130px">
            </td>
            <td style="width: 239px; height: 130px">
                <asp:Button ID="Button1" runat="server" Text="Save" /></td>
        </tr>
    </table>
</asp:Content>

