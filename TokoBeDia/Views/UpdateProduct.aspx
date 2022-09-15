<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="TokoBeDia.Views.UpdateProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group mx-sm-3 mb-2 w-25">
        <form id="UpdateProduct" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="TxtProductName" CssClass="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>

            <asp:Label ID="Label2" runat="server" Text="Product Type"></asp:Label><br />
            
                <asp:DropDownList ID="ddlProductType" CssClass="form-control" runat="server"></asp:DropDownList>
            

            <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="TxtPrice" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

            <asp:Label ID="Label4" runat="server" Text="Stock"></asp:Label>
            <asp:TextBox ID="TxtStock" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>


            <asp:Label ID="Alert" runat="server" CssClass="alert-danger" Text="Please insert all field!" Visible="False"></asp:Label><br />
            <asp:Button ID="btnInsert" runat="server" CssClass="btn btn-success" Text="Update" OnClick="Button1_Click" />
        </form>
    </div>
</asp:Content>
