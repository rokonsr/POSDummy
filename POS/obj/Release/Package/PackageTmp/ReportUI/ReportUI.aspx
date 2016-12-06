<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportUI.aspx.cs" Inherits="POS.ReportUI.ReportUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
  $( function() {
      $("#txtStartDate").datepicker();
      $("#txtEndDate").datepicker();
  } );
  </script>
    <h2>Daily Report</h2>
    <hr />
    <table>
        <tr>
            <td style="width: 167px; height: 40px">
                Start Date
            </td>
            <td>
                <asp:TextBox ID="txtStartDate" ClientIDMode="Static" runat="server" CssClass="form-control" Width="250px" TextMode="Date" ></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtStartDate" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 167px; height: 40px">End Date</td>
            <td>
                <asp:TextBox ID="txtEndDate" ClientIDMode="Static" runat="server" CssClass="form-control" Width="250px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtEndDate" ForeColor="Red" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 167px; height: 40px"></td>
            <td>
                <asp:Button ID="btnPreview" runat="server" Text="Preview" CssClass="btn btn-primary"  Width="75px" OnClick="btnPreview_Click" />
            </td>
        </tr>
    </table>

    <asp:Panel ID="pnlDisplayReportByDate" runat="server" Visible="false">
        <hr />
        <asp:GridView ID="gvDisplayReportByDate" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowDataBound="gvDisplayReportByDate_RowDataBound" ShowFooter="True" CssClass="cellpadding" Width="519px">
            <HeaderStyle CssClass="cellpaddingh" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="TotalQuantity" HeaderText="Total Quantity" />
                <asp:BoundField DataField="TotalPrice" HeaderText="Total Amount" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
    </asp:Panel>

</asp:Content>
