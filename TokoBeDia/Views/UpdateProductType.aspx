<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="UpdateProductType.aspx.cs" Inherits="TokoBeDia.Views.UpdateProductType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Update Product Type</h1>


    <div class="form-group mx-sm-3 mb-2 w-25">
        <form id="LoginForm" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="TxtTypeName" CssClass="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
           

            <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="TxtTypeDesc" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox><br />

        
            

            <asp:Label ID="Alert" runat="server" CssClass="alert-danger"  Text="Please insert all field!" Visible="False"></asp:Label><br />
            <asp:Button ID="btnInsert" runat="server" CssClass="btn btn-success" Text="Update" OnClick="Button1_Click" />
        </form>
        
    </div>
</asp:Content>
