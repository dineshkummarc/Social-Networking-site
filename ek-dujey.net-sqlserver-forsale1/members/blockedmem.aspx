<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="blockedmem.aspx.vb" Inherits="members_blockedmem" title="Members i blocked" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <center>
    <asp:Label ID="label1" runat="server"></asp:Label>
 <asp:GridView ID="gridViewPublishers" runat="server" AllowPaging="True"  AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No records found"
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
                    <table class="splfordata">
                        <tr>
                            <td>
                                <a href='Delblock.aspx?pid=<%# Eval("memberidblocked") %>'>Delete From Block</a><br />
                            </td>
                        </tr>
                        <tr>
                        <td>
                        <%# Eval("fname") %>&nbsp;<%#Eval("lname")%>
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
                                <a href='viewprofile.aspx?pid=<%# Eval("memberidblocked") %>'>View Profile</a><br />
                            </td>
                        </tr>                        
                    </table>
                </ItemTemplate>
                </asp:TemplateField>
            
            <asp:TemplateField>    
                 <ItemTemplate>
        <a href='viewprofile.aspx?pid=<%# Eval("memberidblocked")%>'>
        <asp:Image ID="img" runat="server" Height="80px" Width="100px" /></a>
        
        </ItemTemplate>
        </asp:TemplateField>
            <asp:BoundField DataField="passw" Visible="False" />
       
        
        </Columns>
        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
    </asp:GridView>
    </center>
</asp:Content>

