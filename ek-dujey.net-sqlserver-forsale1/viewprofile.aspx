<%@ Page Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false" CodeFile="viewprofile.aspx.vb" Inherits="viewprofile" title=" Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp;
   


    <br />
    <center>
    <table id="viewp" runat="server" class="splfordata" width="90%">
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="Red" Text=" "></asp:Label></td>
        </tr>
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
                        <td  align="left" id="TD1" runat="server" visible="false">
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
                        <td runat="server">
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
                        <td align="left" valign="top" style="width: 142px">
                        <asp:TextBox id="photopassw" runat="server">Type Password Here</asp:TextBox><br />
                            <asp:Button ID="Button1" runat="server" Text="Insert Password" /></td>
                        <td runat="server" align="left" valign="top">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td  align="left" valign="top" style="width: 142px">
                            Race</td>
                        <td  align="left" id="tdrace" runat="server" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width: 142px">
                            Star Sign</td>
                        <td  align="left" id="tdstarsign" runat="server" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 142px">
                            Diet</td>
                        <td id="tddiet" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 142px">
                            Smoke</td>
                        <td id="tdsmoke" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 142px">
                            Drinking</td>
                        <td id="tddrinking" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 142px">
                            Drugs</td>
                        <td id="tddrugs" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="left"  valign="top" style="width: 142px">
                            Height</td>
                        <td id="tdheight" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 142px">
                            Body Type</td>
                        <td id="tdbodytype" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 142px">
                            Eye Sight</td>
                        <td id="tdeyesight" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 142px">
                            Complexion</td>
                        <td id="tdcomplexion" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 142px">
                            Hair Color</td>
                        <td id="tdhaircolor" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 142px">
                            Marital Status</td>
                        <td align="left"  valign="top" id="tdmaritalstatus" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 142px">
                            First Language</td>
                        <td id="tdmothertounge" runat="server" align="left"   valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 142px">
                            Online Now</td>
                        <td id="tdonline" runat="server" align="left"     valign="top">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td  colspan="2" style="word-wrap:break-word;word-break:break-all;width:550px;" valign="top" align="left" id="tdaboutme" runat="server">
	
            </td>
        </tr>
        <tr>
            <td colspan="2" style="word-wrap:break-word;word-break:break-all;width:550px;" valign="top" align="left" id="tdlookingfor" runat="server">
            </td>
        </tr>
    </table>
    </center>
</asp:Content>

