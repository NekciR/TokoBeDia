<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="TokoBeDia.Views.AddToCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add To Cart</h1>
    <div>
        <form runat="server">
            <asp:Label runat="server" Text="Label" ID="LbProductName"></asp:Label><br />
            <asp:Label runat="server" Text="Label" ID="LbProductPrice"></asp:Label><br />
            <asp:Label runat="server" Text="Label" ID="LbProductStock"></asp:Label><br /><br />

            <asp:Label runat="server" Text="Quantity" ID="Label1" ></asp:Label><br />
            <asp:TextBox ID="TxtQty" runat="server" TextMode="Number" Text="1"></asp:TextBox><br />

            <asp:Label ID="alertRed" CssClass="alert-danger" runat="server" Text="" Visible="false"></asp:Label><br />
            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" Text="Add to Cart" OnClick="Button1_Click" />
        </form>



    </div>
</asp:Content>
