<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="ViewAccount.aspx.cs" Inherits="TokoBeDia.Views.ViewAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>User Profile</h1>
    <div>
        <form runat="server">
            <asp:Label runat="server" Text="Label" ID="LbEmail"></asp:Label><br />
            <asp:Label runat="server" Text="Label" ID="LbName"></asp:Label><br />
            <asp:Label runat="server" Text="Label" ID="LbGender"></asp:Label><br />

            <asp:Button ID="BtnUpdateProfile" runat="server" Text="Change Profile" OnClick="BtnUpdateProfile_Click"  />
            <asp:Button ID="BtnChangePassword" runat="server" Text="Change Password" OnClick="BtnChangePassword_Click" />
        </form>



    </div>
</asp:Content>
