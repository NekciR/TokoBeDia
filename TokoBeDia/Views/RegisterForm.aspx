<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="TokoBeDia.Views.RegisterForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group mx-sm-3 mb-2 w-25">
        <form id="RegisterForm" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server" TextMode="Email" ></asp:TextBox>
            <asp:Label ID="EmailAlert" runat="server" Visible="False" ForeColor="Red"></asp:Label><br />

            <asp:Label ID="Label4" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="TxtName" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:Label ID="NameAlert" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label><br />

            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TxtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label ID="PasswordAlert" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label><br />

            <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="TxtConfirm" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label ID="ConfirmAlert" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label><br />

            <asp:Label ID="Label5" runat="server" Text="Gender : "></asp:Label>
            <asp:RadioButton ID="RbMale" runat="server" GroupName="Gender" Text="Male" />
            <asp:RadioButton ID="RbFemale" runat="server" GroupName="Gender" Text="Female" /> &nbsp
            <asp:Label ID="GenderAlert" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label><br />

            <asp:Label ID="AlertFailLogin" runat="server" CssClass="alert-danger" Text="No such account!" Visible="False"></asp:Label><br />
            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success" Text="Register" OnClick="btnRegister_Click" />
        </form>
    </div>
</asp:Content>

