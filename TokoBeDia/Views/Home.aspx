<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TokoBeDia.Views.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="m-5" style="text-align: center; align-content: center">
        <h1>Welcome,
            <asp:Label ID="LbName" runat="server" Text="Guest"></asp:Label></h1>
        <form runat="server">
            <div runat="server" id="AdminControl" style="margin-bottom:10px;">
                <a href="ViewUser.aspx" Class="btn btn-success">View User</a>
                <a href="InsertProduct.aspx" Class="btn btn-success">Insert Product</a>
                <a href="ViewProductType.aspx" Class="btn btn-success">View Product Type</a>
                <a href="InsertProductType.aspx" Class="btn btn-success">Insert Product Type</a>
                <a href="InsertPaymentType.aspx" Class="btn btn-success">Insert Payment Type</a>
                <a href="ViewPaymentType.aspx" Class="btn btn-success">View Payment Type</a>          
            </div>
             <asp:Label ID="alertRed" CssClass="alert-danger float-right" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Label ID="alertGreen" CssClass="alert-success float-right" runat="server" Text="" Visible="false"></asp:Label>

            <asp:GridView ID="GvHomeProduct" CssClass="ml-auto mr-auto table" runat="server" AutoGenerateColumns="False" OnRowCreated="GvHomeProduct_RowCreated" OnRowUpdating="GvHomeProduct_RowUpdating" OnRowDeleting="GvHomeProduct_RowDeleting" OnRowCommand="GvHomeProduct_RowCommand">
                <Columns>               
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                    <asp:ButtonField ButtonType="Button" CommandName="AddToCart" Text="Add To Cart" HeaderText="Action" ShowHeader="true" />
                    <asp:ButtonField ButtonType="Button" CommandName="Update" Text="Update" HeaderText="Action" ShowHeader="true" />
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" HeaderText="Action" ShowHeader="true" />
                </Columns>
            </asp:GridView>
        </form>
    </div>

</asp:Content>
