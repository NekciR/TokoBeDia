<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="ViewTransaction.aspx.cs" Inherits="TokoBeDia.Views.ViewTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="m-5" style="text-align: center; align-content: center">
        <h1>Welcome,
            <asp:label id="LbName" runat="server" text="Guest"></asp:label>
        </h1>
        <form runat="server">
            <div runat="server" id="AdminControl" style="margin-bottom: 10px;">
                <a href="ViewUser.aspx" class="btn btn-success">View User</a>
                <a href="InsertProduct.aspx" class="btn btn-success">Insert Product</a>
                <a href="ViewProductType.aspx" class="btn btn-success">View Product Type</a>
                <a href="InsertProductType.aspx" class="btn btn-success">Insert Product Type</a>
                <a href="InsertPaymentType.aspx" class="btn btn-success">Insert Payment Type</a>
                <a href="ViewPaymentType.aspx" class="btn btn-success">View Payment Type</a>
                <a href="ViewTransactionReport.aspx" class="btn btn-success">View Transaction Report</a>

            </div>

            <asp:gridview id="GvViewTransaction" cssclass="ml-auto mr-auto table" runat="server" autogeneratecolumns="False"  >
                <Columns>
                    <asp:BoundField DataField="date" HeaderText="Transaction Date" />
                    <asp:BoundField DataField="payment" HeaderText="Payment Type" />
                    <asp:BoundField DataField="product" HeaderText="Product Name" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="subtotal" HeaderText="Subtotal" />
                </Columns>
            </asp:gridview>
        </form>
    </div>
</asp:Content>
