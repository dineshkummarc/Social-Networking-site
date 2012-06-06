<%@ Page Language="VB" MasterPageFile="~/Sadmin/MasterPage.master" AutoEventWireup="false" CodeFile="blockcountries.aspx.vb" Inherits="Sadmin_blockcountries" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 90%">
        <tr>
            <td>
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px">
               
        </tr>
        <tr>
            <td>
            <center>
<asp:Label ID="label1" runat="server">
</asp:Label>
    <asp:GridView ID="gridViewPublishers" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No records found"
        Font-Size="Medium" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gridViewPublishers_PageIndexChanging"
        PagerSettings-Mode="NumericFirstLast" Width="80%">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB"  />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="Black" HorizontalAlign="Center" Font-Size="XX-Large"/>
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="Silver" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
        <a href='removefromdoubtful.aspx?id=<%# Eval("countryname") %>'>Remove Country</a><br />
                    
                </ItemTemplate>
                <ControlStyle Width="10%" />
            </asp:TemplateField>            
            <asp:TemplateField>
             <ItemTemplate>
                                <%#Eval("countryname")%>
                    
                </ItemTemplate>
                </asp:TemplateField>
                
                
                
        </Columns>
        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
    </asp:GridView>
    </center>
                &nbsp;</td></tr></table>
  
</asp:Content>

