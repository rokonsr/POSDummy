using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using POS.BLL;
using POS.DAL;
using POS.Model;

namespace POS.SaleUI
{
    public partial class Sale : BasePage
    {
        private ProductBiz objProductBiz;
        private Product objProduct;
        private SalesBiz objSalesBiz;
        private Sales objSales;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchProductSale.Text))
            {
                pnlSelectProduct.Visible = true;
                ProductAdd();
            }
        }

        private void ProductAdd()
        {
            objProductBiz = new ProductBiz();
            objProduct = new Product();
            objProduct = objProductBiz.AddProductForSale(txtSearchProductSale.Text.Trim());

            txtProductId.Text = objProduct.ProductId.ToString();
            txtProductName.Text = objProduct.ProductName;
            txtQuantity.Text = objProduct.Stock.ToString();
            txtSalePrice.Text = objProduct.SalePrice.ToString();

            txtSearchProductSale.Attributes.Add("onfocus", "this.select()");
            txtSearchProductSale.Focus();
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            pnlSaleProduct.Visible = true;
            if (Convert.ToInt32(txtQuantity.Text) > Convert.ToInt32(txtSaleQuantity.Text))
            {
                if (Session["OrderDetail"] == null)
                {
                    DataTable dt = GetDataTable();
                    DataRow dr = dt.NewRow();
                    dr["ProductId"] = Convert.ToInt32(txtProductId.Text);
                    dr["ProductName"] = txtProductName.Text;
                    dr["StockQuantity"] = Convert.ToInt32(txtQuantity.Text);
                    dr["SaleQuantity"] = Convert.ToInt32(txtSaleQuantity.Text);
                    dr["SalePrice"] = Convert.ToInt32(txtSalePrice.Text);
                    dr["TotalAmount"] = Convert.ToInt32(txtSalePrice.Text) * Convert.ToInt32(txtSaleQuantity.Text);

                    dt.Rows.Add(dr);

                    Session["OrderDetail"] = dt;
                    gvOrderDetail.DataSource = dt;
                    gvOrderDetail.DataBind();

                    ResetField();
                }
                else
                {
                    DataTable dt = (DataTable)Session["OrderDetail"];
                    DataRow[] d = dt.Select("ProductId=" + txtProductId.Text);
                    if (d.Length > 0)
                    {
                        int i;
                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dt.Rows[i]["ProductId"]) == Convert.ToInt32(txtProductId.Text))
                            {
                                dt.Rows[i]["ProductName"] = txtProductName.Text;
                                dt.Rows[i]["StockQuantity"] = Convert.ToInt32(txtQuantity.Text);
                                dt.Rows[i]["SaleQuantity"] = Convert.ToInt32(txtSaleQuantity.Text);
                                dt.Rows[i]["SalePrice"] = Convert.ToInt32(txtSalePrice.Text);
                                dt.Rows[i]["TotalAmount"] = Convert.ToInt32(txtSalePrice.Text) *
                                                            Convert.ToInt32(txtSaleQuantity.Text);
                            }
                        }
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dr["ProductId"] = Convert.ToInt32(txtProductId.Text);
                        dr["ProductName"] = txtProductName.Text;
                        dr["StockQuantity"] = Convert.ToInt32(txtQuantity.Text);
                        dr["SaleQuantity"] = Convert.ToInt32(txtSaleQuantity.Text);
                        dr["SalePrice"] = Convert.ToInt32(txtSalePrice.Text);
                        dr["TotalAmount"] = Convert.ToInt32(txtSalePrice.Text) * Convert.ToInt32(txtSaleQuantity.Text);

                        dt.Rows.Add(dr);
                    }


                    Session["OrderDetail"] = dt;
                    gvOrderDetail.DataSource = dt;
                    gvOrderDetail.DataBind();


                    ResetField();
                }
            }
            else
            {
                MessageBox("Sale Quantity Should Not Greater Than Stock !");

                txtSaleQuantity.Attributes.Add("onfocus", "this.select()");
                txtSaleQuantity.Focus();
            }
        }

        private void ResetField()
        {
            txtSearchProductSale.Text = string.Empty;
            txtProductId.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtSaleQuantity.Text = string.Empty;
            txtSalePrice.Text = string.Empty;
        }

        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductId", typeof(int));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("StockQuantity", typeof(int));
            dt.Columns.Add("SaleQuantity", typeof(int));
            dt.Columns.Add("SalePrice", typeof(int));
            dt.Columns.Add("TotalAmount", typeof(int));

            return dt;
        }

        protected void txtSearchProductSale_TextChanged(object sender, EventArgs e)
        {
            txtSaleQuantity.Attributes.Add("onfocus", "this.select()");
            txtSaleQuantity.Focus();
        }

        protected void gvOrderDetail_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowDelete")
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(((Label)gvr.FindControl("DeleteProduct")).Text);
                DataTable dt = (DataTable)Session["OrderDetail"];

                foreach (DataRow dataRow in dt.Rows)
                {
                    if (Convert.ToInt32(dataRow["ProductId"]) == id)
                    {
                        dataRow.Delete();
                        break;
                    }
                }
                Session["OrderDetail"] = dt;
                gvOrderDetail.DataSource = dt;
                gvOrderDetail.DataBind();

                txtSearchProductSale.Attributes.Add("onfocus", "this.select()");
                txtSearchProductSale.Focus();
            }

            if (gvOrderDetail.Rows.Count == 0)
            {
                pnlSaleProduct.Visible = false;

                txtSearchProductSale.Attributes.Add("onfocus", "this.select()");
                txtSearchProductSale.Focus();
            }
        }

        int totalAmount = 0;

        protected void gvOrderDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalAmount += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text = "Grand Total";
                e.Row.Cells[3].Font.Bold = true;

                e.Row.Cells[4].Text = totalAmount.ToString();
                e.Row.Cells[4].Font.Bold = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["OrderDetail"];

            //string cmdMst = "";
            int i;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                objSalesBiz = new SalesBiz();
                objSales = new Sales();

                objSales.ProductId = Convert.ToInt32(dt.Rows[i][0].ToString());
                objSales.SaleQuantity = float.Parse(dt.Rows[i][3].ToString());
                objSales.SalePrice = float.Parse(dt.Rows[i][4].ToString());

                float stockQuantity = float.Parse(dt.Rows[i][2].ToString());
                float saleQuantity = float.Parse(dt.Rows[i][3].ToString());
                
                objSales.Stock = stockQuantity - saleQuantity;

                objSalesBiz.SaleOrderDetail(objSales);
            }

            MessageBox("You are successfully sale listed products. Thanks!");

            Session.Remove("Order");

            pnlSaleProduct.Visible = false;
        }
    }
}