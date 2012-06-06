<%@ Page Language="VB" MasterPageFile="~/Sadmin/MasterPage.master" AutoEventWireup="false" CodeFile="totalunapprovedphotos.aspx.vb" Inherits="Sadmin_totalunapprovedphotos" title="Photos Waiting For Approval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <asp:Label ID="label1" runat="server">
    </asp:Label>
    
    <asp:GridView ID="gridViewPublishers" runat="server" AllowPaging="True"
        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No records found"
        Font-Size="XX-Large" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gridViewPublishers_PageIndexChanging"
        PagerSettings-Mode="NumericFirstLast" Width="80%">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="Black" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="Silver" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table>
                        <tr>
                            <td align="left">
                                <a href='DelPic.aspx?pid=<%# Eval("photoid") %>'>Delete Photo</a><br />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ControlStyle Width="10%" />
            </asp:TemplateField>
           <asp:TemplateField>
           <ItemTemplate>
           <img alt='<%# Eval("photoname") %>' src='../App_Themes/<%# Eval("photoname") %>' />
           </ItemTemplate>
           </asp:TemplateField>
            
             <asp:TemplateField>
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <a href='photogallery.aspx?pid=<%# Eval("pid") %>'>See Member Photos</a><br />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ControlStyle Width="10%" />
            </asp:TemplateField>
            
            <asp:TemplateField>
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <a href='approvephoto.aspx?pid=<%# Eval("photoid") %>'>Approve Photo</a><br />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ControlStyle Width="10%" />
            </asp:TemplateField>
            
            
            
            
            
        </Columns>
        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
    </asp:GridView>
    </center>
</asp:Content>

