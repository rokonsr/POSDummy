using System;
using System.Collections.Generic;
using POS.BLL;
using POS.DAL;
using POS.Model;
using System.Data;
using System.Web.UI.WebControls;

namespace POS.ProductUI
{
    public partial class AddProduct : BasePage
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

            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CreateProduct() == 1)
            {
                txtProductName.Text = string.Empty;
                ddlCategory.SelectedIndex = 0;
                txtQuantity.Text = string.Empty;
                ddlMeasurement.SelectedIndex = 0;
                txtPurchasePrice.Text = string.Empty;
                txtSalePrice.Text = string.Empty;
            }
        }

        private int CreateProduct()
        {
            objProduct = new Product();
            objProductBiz = new ProductBiz();

            objProduct.ProductName = txtProductName.Text.Trim();
            objProduct.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue.ToString());
            objProduct.Stock = float.Parse(txtQuantity.Text.Trim());
            objProduct.MeasurementId = Convert.ToInt32(ddlMeasurement.SelectedValue.ToString());
            objProduct.PurchasePrice = float.Parse(txtPurchasePrice.Text.Trim());
            objProduct.SalePrice = float.Parse(txtSalePrice.Text.Trim());

            MessageBox(objProductBiz.CreateProduct(objProduct));

            return 1;
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

        protected void btnLoadProduct_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductName.Text.Trim()))
            {
                objProductBiz = new ProductBiz();
                objProduct = new Product();

                objProduct = objProductBiz.SearchExistingProduct(txtProductName.Text.Trim());

                ddlCategory.SelectedValue = objProduct.CategoryId.ToString();
                ddlMeasurement.SelectedIndex = objProduct.MeasurementId;

                txtPurchasePrice.Text = objProduct.PurchasePrice.ToString();
                txtSalePrice.Text = objProduct.SalePrice.ToString();

                txtQuantity.Focus();

                btnSubmit.Text = "Update";
            }
        }
    }
}