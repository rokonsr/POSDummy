using System;
using POS.Model;
using POS.DAL;
using POS.BLL;

namespace POS.CategoryUI
{
    public partial class AddCategory : BasePage
    {
        private Category objCategory;
        private CategoryBiz objCategoryBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CreateCategory() == 1)
            {
                txtCategoryName.Text = string.Empty;
            }
        }

        private int CreateCategory()
        {
            objCategoryBiz = new CategoryBiz();
            objCategory = new Category();

            objCategory.CategoryName = txtCategoryName.Text.Trim();
            MessageBox(objCategoryBiz.CreateCategory(objCategory));

            return 1;
        }
    }
}