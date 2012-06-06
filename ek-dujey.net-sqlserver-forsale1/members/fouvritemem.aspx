<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="fouvritemem.aspx.vb" Inherits="members_fouvritemem" title="Members i like" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<asp:Label ID="label1" runat="server">
</asp:Label>
    <asp:GridView ID="gridViewPublishers" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No records found"
        Font-Size="Small" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gridViewPublishers_PageIndexChanging"
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
                            <td>
                                <a href='DelFav.aspx?pid=<%# Eval("memberidfav") %>'>Delete Favorities</a><br />
                            </td>
                        </tr>
                        <tr>
                        <td>
                        <%# Eval("fname") %>&nbsp;<%# Eval("lname") %>
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
                                <a href='viewprofile.aspx?pid=<%# Eval("memberidfav") %>'>View Profile</a><br />
                            </td>
                        </tr>                        
                    </table>
                </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField>
                <ItemTemplate>
                <a href='viewprofile.aspx?pid=<%# Eval("memberidfav")%>'>
                <asp:Image ID="img" runat="server" Height="80px" Width="100px" /></a>        
                </ItemTemplate>
                </asp:TemplateField>
            <asp:BoundField DataField="passw" Visible="False" />

                
        </Columns>
        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
    </asp:GridView>
    </center>
</asp:Content>

