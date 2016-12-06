<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="POS.CategoryUI.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <script src="../Content/AutoComplete/jquery.js"></script>
    <script src="../Content/AutoComplete/jquery-ui.js"></script>
    <link href="../Content/AutoComplete/jquery-ui.css" rel="stylesheet" />

    <h2>Create Category</h2>
    <hr />
    <table>
        <tr>
            <td style="width: 167px; height: 40px">Category Name</td>
            <td style="height: 40px">
                <asp:TextBox ID="txtCategoryName" ClientIDMode="Static" runat="server" Width="250px" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCategoryName" ForeColor="Red" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 167px; height: 40px"></td>
            <td style="height: 40px">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Create" Width="75px" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
    <script src="../Scripts/CheckExistingCategory.js"></script>
</asp:Content>
