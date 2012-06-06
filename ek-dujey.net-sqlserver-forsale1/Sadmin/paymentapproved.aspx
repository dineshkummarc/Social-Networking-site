<%@ Page Language="VB" MasterPageFile="~/Sadmin/MasterPage.master" AutoEventWireup="false" CodeFile="paymentapproved.aspx.vb" Inherits="Sadmin_paymentapproved" title="Payment Approved" %>
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
         <a href='viewprofile.aspx?pid=<%# Eval("pid") %>'>View Profile</a><br />
        </ItemTemplate>        
            <ControlStyle Width="10%" />
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
        Amount:<%#Eval("amtapproved")%>
        </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField>
        <ItemTemplate>
        <a href='payhim.aspx?pid=<%# Eval("payid") %>'>Pay Him</a><br />
        
        </ItemTemplate>
        </asp:TemplateField>
        
        
       
        <asp:TemplateField>
        <ItemTemplate>
        
        <a href='membershemade.aspx?pid=<%# Eval("pid") %>'>Members He Referd</a>
        </ItemTemplate>
        </asp:TemplateField>
       
       
        </Columns>
           <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom"  />
        
    </asp:GridView>
    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<br />
    </center>
</asp:Content>

