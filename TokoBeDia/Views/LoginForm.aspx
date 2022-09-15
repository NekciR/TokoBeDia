<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="TokoBeDia.Views.LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login</h1>


    <div class="form-group mx-sm-3 mb-2 w-25">
        <form id="LoginForm" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
           

            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TxtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox><br />

            <asp:CheckBox ID="CbRememberMe" runat="server" Text="Remember Me" /><br />
            

            <asp:Label ID="AlertFailLogin" runat="server" CssClass="alert-danger"  Text="No such account!" Visible="False"></asp:Label><br />
            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success" Text="Login" OnClick="Button1_Click" />
        </form>
        
    </div>
</asp:Content>
