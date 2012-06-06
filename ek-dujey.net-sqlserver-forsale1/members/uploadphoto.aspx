<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="uploadphoto.aspx.vb" Inherits="members_uploadphoto" title="Upload your photo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
function formsettings()
{
aspnetForm.enctype="multipart/form-data"
aspnetForm.method="post"
    
}
</script>

    <br />
    <span style="color: #ff3366">Do not Upload Junk Photos, Each Photo is Verified<br />
    </span>
    <asp:FileUpload ID="FileUpload1" runat="server" /><br />
    <br />
    You are Suppose to upload only your photos<br />
    <asp:Button ID="upimage" text="Save Photo" runat="server" /><br />
    <table>
        <tr>
            <td id="TD1" runat="server" style="width: 100px">
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Width="238px"></asp:Label>
</asp:Content>

