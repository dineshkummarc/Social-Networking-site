<%@ Page Language="VB" MasterPageFile="~/Sadmin/MasterPage.master" AutoEventWireup="false" CodeFile="highestreferer.aspx.vb" Inherits="Sadmin_highestreferer" title="Highest Referer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center>
<asp:Label ID="label1" runat="server">
</asp:Label>
   <asp:GridView ID="gridViewPublishers" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast"
                OnPageIndexChanging="gridViewPublishers_PageIndexChanging" 
                runat="server" Width="80%" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="Medium">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="Black"  HorizontalAlign="Center" VerticalAlign="Middle"  Font-Size="XX-Large" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="Silver" />
         
        <Columns>
        <asp:TemplateField>
        <ItemTemplate>
        
          
                        <table>
                            <tr>
                                <td align="left">
                                 <a href='viewprofile.aspx?pid=<%# Eval("pid") %>'>View Profile</a><br />
            
                                </td>
                            </tr>
                            <tr>
                            <td align="left">
                            His IP:<%# Eval("ipaddress") %>
                            </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Email:<%# Eval("email") %><br />
                                    Password:<%# Eval("passw") %>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
        Gender:<%# Eval("gender") %>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="left">
        <%#Eval("countryname")%> 
                                    <br />
                                    <%#Eval("state")%>
                                    <br />
                                    <%# Eval("cityid") %>
                                </td>
                            </tr>
                        </table>
        
        </ItemTemplate>        
            <ControlStyle Width="10%" />
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
        Direct Money:<%#Eval("sum1")%>
        <a href="approveamt.aspx?pid=<%# Eval("pid") %>">Approve Amt</a>
        </ItemTemplate>
        </asp:TemplateField>
        
        
        
        <asp:TemplateField>
        <ItemTemplate>
        
        <a href='membershemade.aspx?pid=<%# Eval("pid") %>'>His Direct Mem</a>
        </ItemTemplate>
        </asp:TemplateField>
       
        </Columns>
           <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom"  />
        
    </asp:GridView>
    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<br />
    </center>
</asp:Content>

