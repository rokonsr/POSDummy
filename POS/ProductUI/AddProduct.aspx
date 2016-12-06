<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="POS.ProductUI.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <script src="../Content/AutoComplete/jquery.js"></script>
    <script src="../Content/AutoComplete/jquery-ui.js"></script>
    <link href="../Content/AutoComplete/jquery-ui.css" rel="stylesheet" />

    <h2>Create Product</h2>
    <hr />
    <table>
        <tr>
            <td style="width: 167px; height: 40px">Name</td>
            <td style="height: 40px; width: 279px;">
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtProductName" runat="server" ClientIDMode="Static" Width="190px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnLoadProduct" runat="server" Text="Load" CssClass="btn btn-primary" Width="60px" CausesValidation="false" OnClick="btnLoadProduct_Click" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="pab" runat="server" ControlToValidate="txtProductName" ErrorMessage="Required Field!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="#cc3300" ErrorMessage="Only Characters Are Allowed" ControlToValidate="txtProductName" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 167px; height: 40px">Category</td>
            <td style="height: 40px; width: 279px;">
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" Width="250px" AppendDataBoundItems="true" >
                    <asp:ListItem Value="0" Text="--Select Category--" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="0" runat="server" ControlToValidate="ddlCategory" ErrorMessage="Required Field!" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 167px; height: 40px">Quantity</td>
            <td style="height: 40px; width: 279px;">
                <asp:TextBox ID="txtQuantity" runat="server" Width="250px" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="pab" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Required Field!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Only Numeric Are Allowed!" ForeColor="#cc3300" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 167px; height: 40px">Measurement</td>
            <td style="height: 40px; width: 279px;">
                <asp:DropDownList ID="ddlMeasurement" runat="server" CssClass="form-control" Width="250px" AppendDataBoundItems="true">
                    <asp:ListItem Value="0" Text="--Select Measurement--" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="0" runat="server" ControlToValidate="ddlMeasurement" ErrorMessage="Required Field!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 167px; height: 40px">Purchase Price</td>
            <td style="height: 40px; width: 279px;">
                <asp:TextBox ID="txtPurchasePrice" runat="server" Width="250px" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="pab" runat="server" ControlToValidate="txtPurchasePrice" ErrorMessage="Required Field!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPurchasePrice" ForeColor="#cc3300" ValidationExpression="^\d+(\.\d\d)?$" ErrorMessage="Only Numeric & Fractional Are Allowed!"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 167px; height: 40px">Sale Price</td>
            <td style="height: 40px; width: 279px;">
                <asp:TextBox ID="txtSalePrice" runat="server" Width="250px" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="pab" runat="server" ControlToValidate="txtSalePrice" ErrorMessage="Required Field!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtSalePrice" ForeColor="#cc3300" ValidationExpression="^\d+(\.\d\d)?$" ErrorMessage="Only Numeric & Fractional Are Allowed!"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 167px; height: 40px"></td>
            <td style="height: 40px; width: 279px;">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" Width="75px" OnClick="btnSubmit_Click"/>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <script src="../Scripts/CheckExistingProduct.js"></script>
</asp:Content>
