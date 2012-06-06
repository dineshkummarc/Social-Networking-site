<%@ Page Language="VB" MasterPageFile="~/Sadmin/MasterPage.master" AutoEventWireup="false" CodeFile="totalmem.aspx.vb" Inherits="Sadmin_totalmem" title="total Members" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetProductsPaged" TypeName="classpartnersearch">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="startRowIndex" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="maximumRows" Type="Int32" />
            <asp:Parameter DefaultValue="left join" Name="jointype" Type="String" />
            <asp:ControlParameter ControlID="TextBox1" DefaultValue="1&lt;&gt;1" Name="sq" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Visible="False">1&lt;&gt;1</asp:TextBox><asp:TextBox
        ID="txtjointype" runat="server" Visible="False"></asp:TextBox><asp:Label ID="Label2"
            runat="server"></asp:Label><asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox><asp:GridView
                ID="gridview1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CellPadding="4" CssClass="splfordata" DataSourceID="ObjectDataSource1" EmptyDataText="No records found"
                Font-Size="Large" ForeColor="#333333" GridLines="None" PagerSettings-Mode="NumericFirstLast"
                Width="80%">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#2461BF" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" Font-Size="XX-Large" ForeColor="Black" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" />
                <AlternatingRowStyle BackColor="Silver" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href='viewprofile.aspx?pid=<%# Eval("pid") %>'>View Profile</a><br />
            Age(<%#DateDiff(DateInterval.Year, Eval("bdate"), Date.Now)%>)<br />
        Gender:<%# Eval("gender") %><br />
        Purpose:<%# Eval("purpose") %><br />
        <%#Eval("countryname")%> 
                            <br />
                            <%#Eval("state")%>
                            <br />
                            <%# Eval("cityid") %>
                        </ItemTemplate>
                        <ControlStyle Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="word-wrap: break-word; word-break: break-all; width: 450px;" valign="top">
                                        <%#cf.BreakWordForWrap(Mid(Eval("whoami"), 1, 300))%>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ControlStyle Width="50%" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Eval("ethnic") %>
                            <br />
                            <%# Eval("religion") %> 
                            <br />
        <%#Eval("caste")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href='viewprofile.aspx?pid=<%# Eval("pid")%>'>
                                <asp:Image ID="img" runat="server" Height="80px" Width="100px" /></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="passw" Visible="False" />
                </Columns>
                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
            </asp:GridView>
    &nbsp;</center>
</asp:Content>

