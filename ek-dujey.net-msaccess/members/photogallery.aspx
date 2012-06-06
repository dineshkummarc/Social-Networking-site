<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="photogallery.aspx.vb" Inherits="members_photogallery" title="Photo Gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td id="tdphoto" runat="server" style="width: 100px">
            </td>
        </tr>
        <tr>
            <td id="tdlink" runat="server" style="width: 100px">
            </td>
        </tr>
    </table>
    <center>
    <asp:GridView ID="gridViewPublishers" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No records found"
        Font-Size="XX-Large" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gridViewPublishers_PageIndexChanging"
        PagerSettings-Mode="NumericFirstLast" PageSize="1" Width="80%">
        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <Columns>
          
            <asp:ImageField DataAlternateTextField="Photoname" DataImageUrlField="photoname"
                DataImageUrlFormatString="../App_Themes/{0}">
                <ControlStyle/>
            </asp:ImageField>
        </Columns>
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="Black" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="Silver" />
    </asp:GridView>
    </center>
</asp:Content>

