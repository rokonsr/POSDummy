using System;
using System.Web.Security;
using POS.BLL;
using POS.DAL;
using POS.Model;

namespace POS
{
    public partial class Login : BasePage
    {
        private UserBiz objUserBiz;
        private User objLoginUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionUtility.POSSessionContainer.OBJ_DOC_CLASS = null;
                SessionUtility.POSSessionContainer.OBJ_CLASS = null;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            objUserBiz = new UserBiz();
            objLoginUser = objUserBiz.GetLoginInfo(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (objLoginUser != null)
            {
                SessionUtility.POSSessionContainer.OBJ_CLASS = objLoginUser;

                FormsAuthentication.RedirectFromLoginPage(objLoginUser.UserName, true);
            }
            else
            {
                MessageBox("Unauthorized Login");
                SessionUtility.POSSessionContainer.OBJ_CLASS = null;
            }
        }
    }
}