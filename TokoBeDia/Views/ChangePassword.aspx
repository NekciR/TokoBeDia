<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TokoBeDia.Views.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Change Password</h1>


    <div class="form-group mx-sm-3 mb-2 w-25">
        <form id="ChangePassword" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Old Password"></asp:Label>
            <asp:TextBox ID="TxtOldPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>

            <asp:Label ID="Label2" runat="server" Text="New Password"></asp:Label>
            <asp:TextBox ID="TxtNewPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>

            <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="TxtConfirm" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>


            <asp:Label ID="Alert" runat="server" CssClass="alert-danger" Text="Please insert all field!" Visible="False"></asp:Label><br />
            <asp:Button ID="btnChangePassword" runat="server" CssClass="btn btn-success" Text="Change" OnClick="Button1_Click" />
        </form>

    </div>
</asp:Content>
