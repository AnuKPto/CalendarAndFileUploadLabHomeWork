<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form id="form1" runat="server">
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
    &nbsp;
        <asp:Button ID="Button1" runat="server" Text="เพิ่มไฟล์" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelUploaded" runat="server" Text="เพิ่มข้อมูลสำเร็จ" Visible="False" BackColor="White" ForeColor="Red"></asp:Label>
    </form>

</asp:Content>

