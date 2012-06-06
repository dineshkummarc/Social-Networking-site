<%@ Page Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false" CodeFile="searchresults.aspx.vb" Inherits="searchresults" title="Search Results" %>
<%@ PreviousPageType VirtualPath="~/default.aspx" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<asp:Label ID="label1" runat="server">
</asp:Label>

    </center>
    <center>
   
     <div>       &nbsp;<asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Visible="False">hid='N'  and DateDiff(yyyy,profile.bdate,getdate())&gt;=18</asp:TextBox>
         <asp:TextBox ID="txtjointype" runat="server" Visible="False">left join</asp:TextBox>
             <asp:GridView ID="gridview1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast"
               
                runat="server" Width="80%" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="Large" DataSourceID="ObjectDataSource1">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="XX-Large" />
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="Black"  HorizontalAlign="Center" Font-Size="XX-Large" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="XX-Large" />
        <AlternatingRowStyle BackColor="Silver" />
         
        <Columns>
        <asp:TemplateField>                  
        <ItemTemplate>
        <table>            
        <tr>
        <td align="left">
            <a href="members/viewprofile.aspx?pid=<%# Eval("pid") %>">View Profile</a><br />
            Age(<%#DateDiff(DateInterval.Year, Eval("bdate"), Date.Now)%>)
        </td> 
        </tr>
        
        <tr>
        <td align="left">
        Gender:<%# Eval("gender") %>
        </td>
        </tr>
        
        <tr>
        <td align="left">
        Purpose:<%# Eval("purpose") %>
        </td>
        </tr>
        
        <tr>
        <td align="left">
        <%#Eval("countryname")%> <br/><%#Eval("state")%><br />  <%# Eval("cityid") %>
        </td>
        </tr>
        </table>
        </ItemTemplate>
            <ControlStyle Width="10%" />
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
        <table width="100%">
        <tr>
        <td style="word-wrap:break-word;word-break:break-all;width:450px;" valign="top">        
        <%#cf.BreakWordForWrap(Mid(Eval("whoami"), 1, 400))%>
        </td>
        </tr>
        </table>
        </ItemTemplate>        
            <ControlStyle Width="50%" />
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
        <table>
        <tr>
        <td  style="font-size:16px;"><%# Eval("ethnic") %></td>
        </tr>
        <tr>
        <td  style="font-size:16px;"><%# Eval("religion") %> </td>
        <tr>
        <td style="font-size:10px;">
        <%#Eval("caste")%>
        </td>
        </tr>
        </tr>
        </table>
        </ItemTemplate> 
        
        </asp:TemplateField>      
        
        
        <asp:TemplateField>
        <ItemTemplate>
        <a href='members/viewprofile.aspx?pid=<%# Eval("pid")%>'>
        <asp:Image ID="img" runat="server" Height="80px" Width="100px" /></a>
        
        </ItemTemplate>
        </asp:TemplateField>
            <asp:BoundField DataField="passw" Visible="False" />
        
        
        
        
        </Columns>
           <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom"  />
        
    </asp:GridView>
      
         <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsPaged" TypeName="classpartnersearch">
             <SelectParameters>
                 <asp:Parameter Name="startRowIndex" Type="Int32" DefaultValue="0" />
                 <asp:Parameter Name="maximumRows" Type="Int32" DefaultValue="0" />
                 <asp:ControlParameter ControlID="txtjointype" Name="jointype" PropertyName="Text"
                     Type="String" DefaultValue="left join" />
                 <asp:ControlParameter ControlID="TextBox1" Name="sq" PropertyName="Text" Type="String" />
             </SelectParameters>
         </asp:ObjectDataSource>
         <asp:HiddenField ID="hdcountry" runat="server" />
         <asp:HiddenField ID="hdage2" runat="server" />
         <asp:HiddenField ID="hdgender" runat="server" />
         <asp:HiddenField ID="hdwithphoto" runat="server" />
         <asp:HiddenField ID="hdage1" runat="server" />
         <asp:HiddenField ID="hdonlinenow" runat="server" />
         <br />
        
    </div>
    </center>
</asp:Content>

