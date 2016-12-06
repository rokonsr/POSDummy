<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sale.aspx.cs" Inherits="POS.SaleUI.Sale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script src="../Content/AutoComplete/jquery.js"></script>
    <script src="../Content/AutoComplete/jquery-ui.js"></script>
    <link href="../Content/AutoComplete/jquery-ui.css" rel="stylesheet" />
    <h2>Sales</h2>
    <hr />
    <table>
        <tr>
            <td style="width: 167px; height: 40px">Sale Product</td>
            <td style="height: 40px">
                <asp:TextBox ID="txtSearchProductSale" runat="server" AutoPostBack="True" ClientIDMode="Static" Width="250px" CssClass="form-control" OnTextChanged="txtSearchProductSale_TextChanged"></asp:TextBox>
            </td>
        </tr>
    </table>

    <asp:Panel ID="pnlSelectProduct" runat="server" Visible="false">
        <hr />
        <table>
            <tr>
                <td>Product Id</td>
                <td>Product Name</td>
                <td>Available Stock</td>
                <td>Sale Quantity</td>
                <td>Sale Price</td>
                <td>Action</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtProductId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtSaleQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtSalePrice" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnAddProduct" runat="server" CssClass="btn btn-primary" Text="Add" Width="75px" OnClick="btnAddProduct_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="txtProductId" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="txtProductName" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="txtQuantity" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ControlToValidate="txtSaleQuantity" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" ControlToValidate="txtSalePrice" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                </td>
            </tr>

        </table>
    </asp:Panel>

    <asp:Panel ID="pnlSaleProduct" runat="server" Visible="false">
        <hr />
        <asp:GridView ID="gvOrderDetail" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" OnRowCommand="gvOrderDetail_RowCommand" OnRowDataBound="gvOrderDetail_RowDataBound" ShowFooter="True" CssClass="cellpadding">
            <HeaderStyle CssClass="cellpaddingh" />
            <Columns>
                <asp:TemplateField HeaderText="Product Id" SortExpression="Product Id">
                    <ItemTemplate>
                        <asp:Label ID="DeleteProduct" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Name" SortExpression="Product Name">
                    <ItemTemplate>
                        <asp:Label ID="ProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sale Quantity" SortExpression="Sale Quantity">
                    <ItemTemplate>
                        <asp:Label ID="SaleQuantity" runat="server" Text='<%# Bind("SaleQuantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sale Price" SortExpression="Sale Price">
                    <ItemTemplate>
                        <asp:Label ID="SalePrice" runat="server" Text='<%# Bind("SalePrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Amount" SortExpression="Total Amount">
                    <ItemTemplate>
                        <asp:Label ID="TotalAmount" runat="server" Text='<%# Bind("TotalAmount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" SortExpression="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="RowDelete" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <hr />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" CausesValidation="False" />
    </asp:Panel>

    <script src="../Scripts/txtSearchProductSale.js"></script>
</asp:Content>
