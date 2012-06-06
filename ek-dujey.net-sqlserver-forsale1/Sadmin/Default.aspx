<%@ Page Language="VB" MasterPageFile="~/Sadmin/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Sadmin_Default" title="Admin Area" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<div id="aa">
    <table>
        <tr>
            <td>
            </td>
            <td style="width: 276px">
            </td>
            <td>
            </td>
            <td style="width: 3px">
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <th>
                            Affilate Program</th>
                    </tr>
                    <tr>
                        <td>
                            Toal Payment Pending</td>
                    </tr>
                    <tr>
                        <td>
                            Coming Soon</td>
                    </tr>
                    <tr>
                        <td>
                            </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Masters</th>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Profile</th>
                            
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Sadmin/editprofile.aspx">Edit Your Profile</asp:HyperLink></td>
                    </tr>
                </table>
            </td>
            <td style="width: 276px">
                <table>
                    <tr>
                        <th>
                            Profiles</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Sadmin/totalmem.aspx">Total Members</asp:HyperLink>
                            <asp:Label ID="lblTotMem" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Sadmin/membersRegistertoday.aspx">Registerd Today</asp:HyperLink>
                            <asp:Label ID="lblRegtoday" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Sadmin/waitingforapproval.aspx">UnApproved Profiles</asp:HyperLink>
                            <asp:Label ID="lblUnApproved" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Sadmin/totalunapprovedphotos.aspx">Unapproved Photos</asp:HyperLink>
                            <asp:Label ID="lblunApprovedPhotos" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Sadmin/doubtfulprofiles.aspx">Doubt Ful Profiles</asp:HyperLink>
                            <asp:Label ID="lblDoubtfulprofile" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Sadmin/suspendedprofiles.aspx">Suspended Profiles</asp:HyperLink>
                            &nbsp;
                            <asp:Label ID="lblsuspendedcount" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Sadmin/searchprofile.aspx">Search Profiles</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Sadmin/resetusersonline.aspx">Reset Users Online</asp:HyperLink></td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
            <td style="vertical-align: top; text-align: left;">
                <table>
                    <tr>
                        <th>
                            Setup and Installation Issues</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://www.websol-dating-software.com/setupandinstall.aspx">Setup And Installation Tutorials</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://www.websol-dating-software.com/commonerrors.aspx">Common Errors and Reasons</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="http://www.websol-dating-software.com/contactus.aspx">Report a Problem,Request a Feature</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="http://www.websol-dating-software.com/earnextramoney.aspx">Earn Money</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="http://www.websol-dating-software.com/configalerts.aspx">Configure Alerts</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Reset all Users Online" Width="221px" /></td>
                    </tr>
                </table>
                <table style="width: 90%">
                    <tr>
                        <th>Scammers Settings
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Sadmin/blockcountries.aspx">Blocked Countries</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Sadmin/opencountries.aspx">Open Countries</asp:HyperLink></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 276px">
            </td>
            <td>
            </td>
            <td style="width: 3px">
                </td>
        </tr>
    </table>
    <br />
    <br />
    </div>
    </center>
</asp:Content>

