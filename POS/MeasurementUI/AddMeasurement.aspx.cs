using System;
using POS.BLL;
using POS.DAL;
using POS.Model;

namespace POS.MeasurementUI
{
    public partial class AddMeasurement : BasePage
    {
        private Measurement objMeasurement;
        private MeasurementBiz objMeasurementBiz;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CreateMeasurement() == 1)
            {
                txtMeasurementName.Text = string.Empty;
            }
        }

        private int CreateMeasurement()
        {
            objMeasurementBiz = new MeasurementBiz();
            objMeasurement = new Measurement();

            objMeasurement.MeasurementName = txtMeasurementName.Text.Trim();
            MessageBox(objMeasurementBiz.CreateMeasurement(objMeasurement));

            return 1;
        }
    }
}