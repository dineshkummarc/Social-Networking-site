<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="uploadphoto.aspx.vb" Inherits="members_uploadphoto" title="Upload your photo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript">
function formsettings()
{
aspnetForm.enctype="multipart/form-data"
aspnetForm.method="post"
    
}
</script>

    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" /><br />
    <br />
    <asp:Button ID="upimage" text="Save Photo" runat="server" /><br />
    <br />
    <asp:Label ID="Label1" runat="server" Width="238px"></asp:Label>
</asp:Content>

