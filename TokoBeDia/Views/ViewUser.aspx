<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="TokoBeDia.Views.ViewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="m-5" style="text-align: center; align-content: center">
        <h1>Welcome,
            <asp:Label ID="LbName" runat="server" Text="Guest"></asp:Label></h1>
        <form runat="server">
            <div runat="server" id="AdminControl" style="margin-bottom: 10px;">
                <a href="ViewUser.aspx" class="btn btn-success">View User</a>
                <a href="InsertProduct.aspx" class="btn btn-success">Insert Product</a>
                <a href="ViewProductType.aspx" class="btn btn-success">View Product Type</a>
                <a href="InsertProductType.aspx" class="btn btn-success">Insert Product Type</a>
                <a href="InsertPaymentType.aspx" Class="btn btn-success">Insert Payment Type</a>
                <a href="ViewPaymentType.aspx" Class="btn btn-success">View Payment Type</a> 

            </div>

            <asp:GridView ID="GvUserList" CssClass="ml-auto mr-auto table" AutoGenerateColumns="False" runat="server" OnRowDataBound="GvUserList_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField HeaderText="Role" />

                    <asp:TemplateField HeaderText="Role">
                        <ItemTemplate>
                            <asp:DropDownList runat="server" ID="ddlRole" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" AutoPostBack="true" EnableViewState="true" ViewStateMode="Enabled"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:DropDownList runat="server" ID="ddlStatus" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true" EnableViewState="true" ViewStateMode="Enabled"></asp:DropDownList>
                        </ItemTemplate>         
                    </asp:TemplateField>
                    <asp:BoundField DataField="Status" HeaderText="Status" />





                </Columns>
            </asp:GridView>
        </form>
    </div>

</asp:Content>

