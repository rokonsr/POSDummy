using System;
using System.Data;
using System.Data.Common;
using POS.DAL;
using POS.Model;

namespace POS.BLL
{
    public class SalesBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForSale(DbDataReader objDataReader, Sales objSale)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "SaleId":
                        if (!Convert.IsDBNull(objDataReader["SaleId"]))
                        {
                            objSale.SaleId = Convert.ToInt32(objDataReader["SaleId"]);
                        }
                        break;
                    case "ProductId":
                        if (!Convert.IsDBNull(objDataReader["ProductId"]))
                        {
                            objSale.ProductId = Convert.ToInt32(objDataReader["ProductId"].ToString());
                        }
                        break;
                    case "SaleQuantity":
                        if (!Convert.IsDBNull(objDataReader["SaleQuantity"]))
                        {
                            objSale.SaleQuantity = float.Parse(objDataReader["SaleQuantity"].ToString());
                        }
                        break;
                    case "SalePrice":
                        if (!Convert.IsDBNull(objDataReader["SalePrice"]))
                        {
                            objSale.SalePrice = float.Parse(objDataReader["SalePrice"].ToString());
                        }
                        break;
                    case "StartDate":
                        if (!Convert.IsDBNull(objDataReader["StartDate"]))
                        {
                            objSale.StartDate = (DateTime)objDataReader["StartDate"];
                        }
                        break;
                    case "EndDate":
                        if (!Convert.IsDBNull(objDataReader["EndDate"]))
                        {
                            objSale.EndDate = (DateTime)objDataReader["EndDate"];
                        }
                        break;
                    case "Stock":
                        if (!Convert.IsDBNull(objDataReader["Stock"]))
                        {
                            objSale.Stock = float.Parse(objDataReader["Stock"].ToString());
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public DataTable GetSalesReportByDate(string startDate, string endDate)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            DataTable dt = new DataTable();

            try
            {
                objDbCommand.AddInParameter("StartDate", startDate);
                objDbCommand.AddInParameter("EndDate", endDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "uspSearchSaleProductByDate", CommandType.StoredProcedure);

                //if (objDbDataReader.HasRows)
                //{
                //    while (objDbDataReader.Read())
                //    {
                //        objSearchUser = new SearchUser();
                //        this.BuildModelForSearchUser(objDbDataReader, objSearchUser);

                //        objUserList.Add(objSearchUser);
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }

        public string SaleOrderDetail(Sales objSales)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("ProductId", objSales.ProductId);
            objDbCommand.AddInParameter("SaleQuantity", objSales.SaleQuantity);
            objDbCommand.AddInParameter("SalePrice", objSales.SalePrice);
            objDbCommand.AddInParameter("Stock", objSales.Stock);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "uspInsertSaleDetail", CommandType.StoredProcedure);

                if (noOfAffacted > 0)
                {
                    objDbCommand.Transaction.Commit();
                    return "Update Successful";
                }
                else
                {
                    objDbCommand.Transaction.Rollback();
                    return "Update Failed";
                }
            }
            catch (Exception ex)
            {
                objDbCommand.Transaction.Rollback();
                throw new Exception("Database Error Occured", ex);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }
        }
    }
}
