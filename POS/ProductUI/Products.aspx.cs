using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using POS.BLL;
using POS.DAL;
using POS.Model;

namespace POS.ProductUI
{
    public partial class Products : BasePage
    {
        private Product objProduct;
        private ProductBiz objProductBiz;
        private Category objCategory;
        private CategoryBiz objCategoryBiz;
        private Measurement objMeasurement;
        private MeasurementBiz objMeasurementBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownForCategory();
                PopulateDropDownForMeasurement();
            }
            BindProductGrid();
        }

        private void BindProductGrid()
        {
            objProductBiz = new ProductBiz();
            DataTable dtProduct = new DataTable();
            dtProduct = objProductBiz.GetProduct(txtSearchProduct.Text.Trim());
            gvGetProduct.DataSource = dtProduct;
            gvGetProduct.DataBind();

            gvGetProduct.ShowHeaderWhenEmpty = true;
            gvGetProduct.EmptyDataText = "There is no matching records found!";

            txtSearchProduct.Attributes.Add("onfocus", "this.select()");
            txtSearchProduct.Focus();
        }

        protected void gvGetProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlUpdateProduct.Visible = true;

            txtProductName.Text = gvGetProduct.SelectedRow.Cells[1].Text;
            ddlCategory.SelectedItem.Text = gvGetProduct.SelectedRow.Cells[2].Text;
            txtQuantity.Text = gvGetProduct.SelectedRow.Cells[3].Text;
            ddlMeasurement.SelectedItem.Text = gvGetProduct.SelectedRow.Cells[4].Text;
            txtPurchasePrice.Text = gvGetProduct.SelectedRow.Cells[5].Text;
            txtSalePrice.Text = gvGetProduct.SelectedRow.Cells[6].Text;
        }

        private void PopulateDropDownForCategory()
        {
            objCategory = new Category();
            objCategoryBiz = new CategoryBiz();
            List<Category> objCategoryList = new List<Category>();
            objCategoryList = objCategoryBiz.GetCategoryList();
            ddlCategory.DataSource = objCategoryList;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
        }

        private void PopulateDropDownForMeasurement()
        {
            objMeasurement = new Measurement();
            objMeasurementBiz = new MeasurementBiz();
            List<Measurement> objMeasurementList = new List<Measurement>();
            objMeasurementList = objMeasurementBiz.GetMeasurementList();
            ddlMeasurement.DataSource = objMeasurementList;
            ddlMeasurement.DataValueField = "MeasurementId";
            ddlMeasurement.DataTextField = "MeasurementName";
            ddlMeasurement.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateProductInformation() == 1)
            {
                BindProductGrid();
                pnlUpdateProduct.Visible = false;
            }
        }

        private int UpdateProductInformation()
        {
            objProduct = new Product();
            objProductBiz = new ProductBiz();

            GridViewRow row = gvGetProduct.SelectedRow;

            objProduct.ProductId = Convert.ToInt32(gvGetProduct.DataKeys[row.RowIndex].Values[0].ToString());
            objProduct.ProductName = txtProductName.Text.Trim();
            objProduct.CategoryId = Convert.ToInt32( ddlCategory.SelectedItem.Value);
            objProduct.Stock = Convert.ToInt32(txtQuantity.Text.Trim());
            objProduct.MeasurementId = Convert.ToInt32(ddlMeasurement.SelectedItem.Value);
            objProduct.PurchasePrice = float.Parse(txtPurchasePrice.Text.Trim());
            objProduct.SalePrice = float.Parse(txtSalePrice.Text.Trim());

            MessageBox(objProductBiz.UpdateProductInformation(objProduct));

            return 1;

            pnlUpdateProduct.Visible = true;
        }

        protected void gvGetProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGetProduct.PageIndex = e.NewPageIndex;
            this.BindProductGrid();
        }
    }
}