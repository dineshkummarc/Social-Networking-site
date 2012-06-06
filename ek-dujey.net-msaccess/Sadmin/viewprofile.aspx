<%@ Page Language="VB" MasterPageFile="~/Sadmin/MasterPage.master" AutoEventWireup="false" CodeFile="viewprofile.aspx.vb" Inherits="Sadmin_viewprofile" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
&nbsp; &nbsp;
    <br />
    <center>
    <table id="viewp" runat="server" class="splfordata" width="90%">
        <tr>
            <td runat="server" colspan="2">
                <asp:Button ID="Button4" runat="server" Text="Delete Profile" /></td>
        </tr>
    <tr>
    <td colspan="2" id="tdheadline" runat="server"></td>
    </tr>
        <tr>
            <td valign="top">
            
                <table>
                    <tr>
                        <td id="TD4">
                            Username</td>
                        <td id="tdusername" runat="server" style="width: 3px">
                            rt</td>
                    </tr>
                    <tr>
                        <td>
                            Password</td>
                        <td id="tdpassword" runat="server" style="width: 3px">
                            ty</td>
                    </tr>
                <tr>
                <td>Profile Id</td>
                <td runat="server" id="tdpid" style="width: 3px"></td>
                </tr>
                    <tr>
                        <td  align="left">
                            Reg Date</td>
                        <td  runat="server" id="tdregdate" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            Last Visited Date</td>
                        <td  id="tdlastvisited" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            Last Update</td>
                        <td  id="tdlastupdate" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            Name</td>
                        <td  id="tdname" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left" valign="top">
                            Age</td>
                        <td  id="tdage" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="left">
                            Sex</td>
                        <td  id="tdsex" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Purpose</td>
                        <td id="tdpurpose" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Education</td>
                        <td  id="tdeducation" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Profession</td>
                        <td id="tdprofession" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Annual Income</td>
                        <td id="tdincome" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Religion</td>
                        <td id="tdreligion" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            Caste</td>
                        <td  id="tdcaste" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            Location</td>
                        <td  id="tdlocation" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" >
                            Pin</td>
                        <td id="tdpincode" runat="server" style="width: 3px">
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table>
                    <tr>
                        <td colspan="2" valign="top" id="tdimage" runat="server">
                        
                            </td>
                    </tr>
                    <tr>
                        <td id="Td1" runat="server" colspan="2" valign="top">
                            <asp:Button ID="Button1" runat="server" Text="Approve Profile" /></td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" id="favcell" runat="server" style="width: 173px">
                            &nbsp;<asp:Button ID="Button2" runat="server" Text="Approve with Photo" /></td>
                        <td id="Td2" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 173px" valign="top">
                            <asp:Button ID="Button3" runat="server" Text="Edit Profile" /></td>
                        <td runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left" valign="top" style="width: 173px">
                            Race</td>
                        <td  align="left" id="tdrace" runat="server" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width: 173px">
                            Star Sign</td>
                        <td  align="left" id="tdstarsign" runat="server" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Diet</td>
                        <td id="tddiet" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Smoke</td>
                        <td id="tdsmoke" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Drinking</td>
                        <td id="tddrinking" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Drugs</td>
                        <td id="tddrugs" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Height</td>
                        <td id="tdheight" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Body Type</td>
                        <td id="tdbodytype" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Eye Sight</td>
                        <td id="tdeyesight" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Complexion</td>
                        <td id="tdcomplexion" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Hair Color</td>
                        <td id="tdhaircolor" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Marital Status</td>
                        <td align="left"  valign="top" id="tdmaritalstatus" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            First Language</td>
                        <td id="tdmothertounge" runat="server" align="left"   valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Online Now</td>
                        <td id="tdonline" runat="server" align="left"     valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" id="tdblocked" runat="server" style="width: 173px">
                            </td>
                        <td id="Td3" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="word-wrap:break-word;word-break:break-all;width:750px;" valign="top" align="left" id="tdaboutme" runat="server">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="word-wrap:break-word;word-break:break-all;width:750px;" valign="top" align="left" id="tdlookingfor" runat="server">
            </td>
        </tr>
    </table>
    </center>
</asp:Content>

