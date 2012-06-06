<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="members_Default" title="Welcome to Your Member Area" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <table width="90%">
        <tr>
            <td colspan="3">
            
            </td>
        </tr>
        
        <tr>
            <td valign="top">
                <table>
                    <tr>
                        <th valign="top">
                            Search</th>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/members/findpartner.aspx">Find Partner</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            </td>
                    </tr>
                    
                </table>
                <br />
                <table>
                <tr>
                <th>Referals
                </th>
                </tr>
                    <tr>                    
                        <td style="width: 100px">
                            <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/members/reflink.aspx">Referal Link</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                    </tr>
                </table>
            </td>
            
            <td valign="top">
                <table>
                    <tr>
                        <th>
                            Groups</th>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/members/fouvritemem.aspx">Fouvrite Members</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/members/blockedmem.aspx">Blocked Member</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                            </td>
                    </tr>
                </table>
                <br />
                <table>
                <tr>
                <th>Views</th>
                </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/members/whoviewdyourprofile.aspx">Who Viewed My Profile?</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/members/profileviewedbyyou.aspx">Profiles You Viewed</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table>
                    <tr>
                        <th>
                            Profile</th>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/members/editreg.aspx">Edit Profile</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/members/uploadphoto.aspx">Upload/Delete Photo</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink7" runat="server"  Target="_blank"  >View Your Profile</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
                <br />
                <% If cf.affprogram = "Y" Then%>
                <table>
                <tr>
                <th>Money Earned</th>
                </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/members/affprogram.aspx">Ref Program Details</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            Total Unpaid Money Earned
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Your Referals&nbsp;
                            <asp:HyperLink ID="hypdirectref" runat="server" NavigateUrl="~/members/directmemreferd.aspx">HyperLink</asp:HyperLink></td>
                    </tr>
                </table>
                <% end if %>
            </td>
        </tr>
        <tr>
            <td>                
                <table>
                    <tr>
                        <th>
                            Alerts</th>
                    </tr>
                    <tr>
                        <td align="left">
                          
                          <asp:GridView ID="gridViewPublishers" AutoGenerateColumns="False"
                EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast"
                OnPageIndexChanging="gridViewPublishers_PageIndexChanging" 
                runat="server" Width="80%" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="medium">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="Black"  HorizontalAlign="Center"  />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="Silver" />
         
        <Columns>
        <asp:TemplateField>
        <ItemTemplate>
        <table>     
        <tr>
        <td>
            <a href="delalert.aspx?alid=<%# Eval("searchno") %>">Delete Alert</a><br />
            
        </td> 
        </tr>
        
       
        </table>
        </ItemTemplate>
       
        </asp:TemplateField>        
       
       <asp:TemplateField>
        <ItemTemplate>
        <table class="splfordata1">     
        <tr> 
        <td>
            <a href="runalert.aspx?alid=<%# Eval("searchno") %>">Run Alert (<%#Eval("queryname")%>)</a><br />
            
        </td> 
        </tr>
        
       
        </table>
        </ItemTemplate>
       
        </asp:TemplateField>        
        
        </Columns>
           <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom"  />
        
    </asp:GridView>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center" valign="top">
                <table>
                    <tr>
                        <th>
                            Privacy Settings</th>
                    </tr>
                    <tr>
                        <td align="left"> 
                            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/members/privacysettings.aspx">Privacy Settings</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/members/reqpasswordlist.aspx"
                                >Photo Password Request List</asp:HyperLink></td>
                    </tr>
                </table>
            </td>
            <td align="center" valign="top"> 
                <table>
                    <tr>
                        <th>
                            Removal</th>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/members/RemoveProfile.aspx">Remove Profile</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/members/removephoto.aspx">Remove Photo</asp:HyperLink></td>
                    </tr>
                </table>
            </td>
        </tr>
      
    </table>
    </center>
</asp:Content>

