using System;

namespace POS.DAL
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            this.MaintainScrollPositionOnPostBack = true;
        }

        protected override void InitializeCulture()
        {
            string cultureName = "en-GB";
            this.UICulture = cultureName;
            this.Culture = cultureName;
            System.Globalization.CultureInfo objCultureInfo = new System.Globalization.CultureInfo(cultureName);
            objCultureInfo.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
            System.Threading.Thread.CurrentThread.CurrentCulture = objCultureInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = objCultureInfo;
            base.InitializeCulture();
        }

        public void MessageBox(String message)
        {
            System.Web.UI.WebControls.Label lblMessageBoxForAlert = new System.Web.UI.WebControls.Label();
            lblMessageBoxForAlert.ID = "testjavascriptlabelid";
            lblMessageBoxForAlert.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert(" + "'" + message + "'" + ");</script>";
            Page.Controls.Add(lblMessageBoxForAlert);
        }
    }
}
