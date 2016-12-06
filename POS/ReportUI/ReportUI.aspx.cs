using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using POS.BLL;
using POS.Model;

namespace POS.ReportUI
{
    public partial class ReportUI : System.Web.UI.Page
    {
        private Sales objSales;
        private SalesBiz objSalesBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductGrid();
            }
        }

        int totalAmount = 0;
        protected void gvDisplayReportByDate_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalAmount += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalPrice"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Grand Total";
                e.Row.Cells[2].Font.Bold = true;

                e.Row.Cells[3].Text = totalAmount.ToString();
                e.Row.Cells[3].Font.Bold = true;
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            pnlDisplayReportByDate.Visible = true;
            BindProductGrid();
        }

        private void BindProductGrid()
        {
            objSalesBiz = new SalesBiz();
            DataTable dtReport = new DataTable();

            dtReport = objSalesBiz.GetSalesReportByDate(txtStartDate.Text, txtEndDate.Text);

            gvDisplayReportByDate.DataSource = dtReport;
            gvDisplayReportByDate.DataBind();

            gvDisplayReportByDate.ShowHeaderWhenEmpty = true;
            gvDisplayReportByDate.EmptyDataText = "There is no data in selected date";
        }
    }
}