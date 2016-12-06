using POS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POS.Model;

namespace POS
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (SessionUtility.POSSessionContainer.OBJ_CLASS != null)
                {
                    User objLoginUser = new User();
                    objLoginUser = (User)SessionUtility.POSSessionContainer.OBJ_CLASS;
                    
                    Session["DisplayUserName"] = objLoginUser.Name;
                }

                if (Session["DisplayUserName"] != null)
                {
                    displayUserName.Text = Session["DisplayUserName"].ToString();
                }
            }

            if (SessionUtility.POSSessionContainer.OBJ_CLASS == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}