<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="TokoBeDia.Views.ViewCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="m-5" style="text-align: center; align-content: center">
       
        <h1>Welcome,
            <asp:Label ID="LbName" runat="server" Text="Guest"></asp:Label></h1>
        <form runat="server" id="form">
      
            <asp:Label ID="alertRed" CssClass="alert-danger float-right" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Label ID="alertGreen" CssClass="alert-success float-right" runat="server" Text="" Visible="false"></asp:Label><br />

            <asp:Label ID="lblNoItem" CssClass="text-muted" runat="server" Text="Empty Cart!" Visible="false"></asp:Label>

            <asp:GridView ID="GvViewCart" CssClass="ml-auto mr-auto table" runat="server" AutoGenerateColumns="False" OnRowDeleting="GvViewCart_RowDeleting" OnRowUpdating="GvViewCart_RowUpdating" OnRowDataBound="GvViewCart_RowDataBound" >
                <Columns>
                    <asp:BoundField DataField="productId" HeaderText="ID" />
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="price" HeaderText="Price" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="subtotal" HeaderText="Subtotal" />
                    <asp:ButtonField ButtonType="Button" CommandName="Update" Text="Update" HeaderText="Action" ShowHeader="true" />
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" HeaderText="Action" ShowHeader="true" />
                </Columns>
            </asp:GridView>

            <asp:Label ID="lblGrandTotal" runat="server" Text=""></asp:Label><br /><br />
            <asp:DropDownList runat="server" ID="ddlPayment"></asp:DropDownList><br /><br />
            <asp:Button runat="server" ID="btnCheckout" Text="Check Out" CssClass="btn btn-success" OnClick="btnCheckout_Click" />
        </form>
    </div>
</asp:Content>
