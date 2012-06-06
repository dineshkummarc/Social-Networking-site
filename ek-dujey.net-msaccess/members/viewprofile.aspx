<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="viewprofile.aspx.vb" Inherits="members_viewprofile" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br />
    <center>
    <table id="viewp" runat="server" class="splfordata"  width="90%">
    <tr>
    <td colspan="2" id="tdheadline" runat="server"></td>
    </tr>
        <tr>
            <td valign="top">
            
                <table>
                <tr>
                <td>Profile Id</td>
                <td runat="server" id="tdpid"></td>
                </tr>
                    <tr>
                        <td  align="left">
                            Reg Date</td>
                        <td  runat="server" id="tdregdate">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            Last Visited Date</td>
                        <td  id="tdlastvisited" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            Last Update</td>
                        <td  id="tdlastupdate" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            Name</td>
                        <td  id="tdname" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left" valign="top">
                            Age</td>
                        <td  id="tdage" runat="server">
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="left">
                            Sex</td>
                        <td  id="tdsex" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Purpose</td>
                        <td id="tdpurpose" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Education</td>
                        <td  id="tdeducation" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Profession</td>
                        <td id="tdprofession" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Annual Income</td>
                        <td id="tdincome" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Religion</td>
                        <td id="tdreligion" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            Caste</td>
                        <td  id="tdcaste" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            Location</td>
                        <td  id="tdlocation" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" >
                            Pin</td>
                        <td id="tdpincode" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Button ID="btnContact" runat="server" Text="Contact This Member" /></td>
                        <td id="Td1" runat="server">
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
                    <td>
                    <asp:Label ID="totalphoto" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                        <td id="Td2" runat="server" colspan="2" valign="top">
                        <asp:TextBox id="photopassw" runat="server">Type Password Here</asp:TextBox><br />
                            <asp:Button ID="Button1" runat="server" Text="Photo Password" /></td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" id="favcell" runat="server">
                        
                        <asp:LinkButton ID="addtofav" runat="server">Add To Favorities</asp:LinkButton>                        
                        
                            </td>
                        <td id="Td3" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left" valign="top">
                            Race</td>
                        <td  align="left" id="tdrace" runat="server" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Star Sign</td>
                        <td  align="left" id="tdstarsign" runat="server" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top">
                            Diet</td>
                        <td id="tddiet" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top">
                            Smoke</td>
                        <td id="tdsmoke" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top">
                            Drinking</td>
                        <td id="tddrinking" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top">
                            Drugs</td>
                        <td id="tddrugs" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="left"  valign="top">
                            Height</td>
                        <td id="tdheight" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top">
                            Body Type</td>
                        <td id="tdbodytype" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top">
                            Eye Sight</td>
                        <td id="tdeyesight" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top">
                            Complexion</td>
                        <td id="tdcomplexion" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top">
                            Hair Color</td>
                        <td id="tdhaircolor" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top">
                            Marital Status</td>
                        <td align="left"  valign="top" id="tdmaritalstatus" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top">
                            First Language</td>
                        <td id="tdmothertounge" runat="server" align="left"   valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top">
                            Online Now</td>
                        <td id="tdonline" runat="server" align="left"     valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" id="tdblocked" runat="server">
                            <asp:LinkButton ID="LinkButton1" runat="server">Block this Member</asp:LinkButton></td>
                        <td id="Td4" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="word-wrap:break-word;word-break:break-all;width:450px;" valign="top" align="left" id="tdaboutme" runat="server">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="word-wrap:break-word;word-break:break-all;width:550px;" valign="top" align="left" id="tdlookingfor" runat="server">
            </td>
        </tr>
    </table>
    </center>
</asp:Content>

