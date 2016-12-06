<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="POS.ProductUI.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <script src="../Content/AutoComplete/jquery.js"></script>
    <script src="../Content/AutoComplete/jquery-ui.js"></script>
    <link href="../Content/AutoComplete/jquery-ui.css" rel="stylesheet" />

    <h2>Product List</h2>
    <hr />
    <table>
        <tr>
            <td style="width: 167px; height: 40px">Search Product</td>
            <td style="height: 40px">
                <asp:TextBox ID="txtSearchProduct" runat="server" AutoPostBack="True" ClientIDMode="Static" Width="250px" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
    </table>
    <hr />
    <asp:Panel ID="pnlDisplayProductGrid" runat="server">
        <div style="overflow:auto; height:250px; padding-left:20px;">
        <asp:GridView ID="gvGetProduct" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" GridLines="Vertical" CssClass="cellpadding" OnSelectedIndexChanged="gvGetProduct_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="ProductId" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvGetProduct_PageIndexChanging">
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ControlStyle-Font-Underline="true" ControlStyle-ForeColor="Blue" HeaderText="Action" SelectText="Edit" ShowHeader="True" ShowSelectButton="True">
                <ControlStyle Font-Underline="True" ForeColor="Blue" />
                </asp:CommandField>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                <asp:BoundField DataField="Stock" HeaderText="Quantity" />
                <asp:BoundField DataField="MeasurementName" HeaderText="Measurement Name" />
                <asp:BoundField DataField="PurchasePrice" HeaderText="Purchase Price" />
                <asp:BoundField DataField="SalePrice" HeaderText="Sale Price" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle CssClass="cellpaddingh" />
            <PagerSettings Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous" />
            <PagerStyle BackColor="#000084" BorderColor="Blue" BorderWidth="1" Font-Underline="true" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
            </div>
    </asp:Panel>

    <asp:Panel ID="pnlUpdateProduct" runat="server" Visible="false">
        <hr />
        <table>
            <tr>
            <td style="width: 167px; height: 40px">Name</td>
            <td style="height: 40px; width: 279px;">
                <asp:TextBox ID="txtProductName" runat="server" Width="250px" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName" ErrorMessage="Required Field!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 167px; height: 40px">Category</td>
            <td style="height: 40px; width: 279px;">
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" Width="250px" >                   
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCategory" ErrorMessage="Required Field!" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 167px; height: 40px">Quantity</td>
            <td style="height: 40px; width: 279px;">
                <asp:TextBox ID="txtQuantity" runat="server" Width="250px" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Required Field!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 167px; height: 40px">Measurement</td>
            <td style="height: 40px; width: 279px;">
                <asp:DropDownList ID="ddlMeasurement" runat="server" CssClass="form-control" Width="250px">
                    
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlMeasurement" ErrorMessage="Required Field!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 167px; height: 40px">Purchase Price</td>
            <td style="height: 40px; width: 279px;">
                <asp:TextBox ID="txtPurchasePrice" runat="server" Width="250px" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPurchasePrice" ErrorMessage="Required Field!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 167px; height: 40px">Sale Price</td>
            <td style="height: 40px; width: 279px;">
                <asp:TextBox ID="txtSalePrice" runat="server" Width="250px" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSalePrice" ErrorMessage="Required Field!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
            <tr>
                <td style="width: 167px; height: 40px"></td>
                <td style="height: 40px">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn-primary" Text="Update" Width="75px" OnClick="btnUpdate_Click" />
                </td>
            </tr>
                        
        </table>
    </asp:Panel>

    <script src="../Scripts/txtSearch.js"></script>

</asp:Content>
