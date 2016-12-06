using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POS.DAL;
using POS.Model;

namespace POS.BLL
{
    public class ProductBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForProduct(DbDataReader objDataReader, Product objProduct)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "ProductId":
                        if (!Convert.IsDBNull(objDataReader["ProductId"]))
                        {
                            objProduct.ProductId = Convert.ToInt32(objDataReader["ProductId"]);
                        }
                        break;
                    case "ProductName":
                        if (!Convert.IsDBNull(objDataReader["ProductName"]))
                        {
                            objProduct.ProductName = objDataReader["ProductName"].ToString();
                        }
                        break;
                    case "CategoryId":
                        if (!Convert.IsDBNull(objDataReader["CategoryId"]))
                        {
                            objProduct.CategoryId = Convert.ToInt32(objDataReader["CategoryId"].ToString());
                        }
                        break;
                    case "CategoryName":
                        if (!Convert.IsDBNull(objDataReader["CategoryName"]))
                        {
                            objProduct.CategoryName = objDataReader["CategoryName"].ToString();
                        }
                        break;
                    case "Stock":
                        if (!Convert.IsDBNull(objDataReader["Stock"]))
                        {
                            objProduct.Stock = float.Parse(objDataReader["Stock"].ToString());
                        }
                        break;
                    case "MeasurementId":
                        if (!Convert.IsDBNull(objDataReader["MeasurementId"]))
                        {
                            objProduct.MeasurementId = Convert.ToInt32(objDataReader["MeasurementId"].ToString());
                        }
                        break;
                    case "MeasurementName":
                        if (!Convert.IsDBNull(objDataReader["MeasurementName"]))
                        {
                            objProduct.MeasurementName = objDataReader["MeasurementName"].ToString();
                        }
                        break;
                    case "PurchasePrice":
                        if (!Convert.IsDBNull(objDataReader["PurchasePrice"]))
                        {
                            objProduct.PurchasePrice = float.Parse(objDataReader["PurchasePrice"].ToString());
                        }
                        break;
                    case "SalePrice":
                        if (!Convert.IsDBNull(objDataReader["SalePrice"]))
                        {
                            objProduct.SalePrice = float.Parse(objDataReader["SalePrice"].ToString());
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public string CreateProduct(Product objProduct)
        {
            int noOfAffacted = 0;


            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("ProductName", objProduct.ProductName);
            objDbCommand.AddInParameter("ProductCategory", objProduct.CategoryId);
            objDbCommand.AddInParameter("Stock", objProduct.Stock);
            objDbCommand.AddInParameter("MeasurementName", objProduct.MeasurementId);
            objDbCommand.AddInParameter("PurchasePrice", objProduct.PurchasePrice);
            objDbCommand.AddInParameter("SalePrice", objProduct.SalePrice);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "uspCreateProduct", CommandType.StoredProcedure);

                if (noOfAffacted > 0)
                {
                    objDbCommand.Transaction.Commit();
                    return "Save Successful";
                }
                else
                {
                    objDbCommand.Transaction.Rollback();
                    return "Save Failed";
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

        public Product SearchExistingProduct(string productName)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            Product objProduct = null;
            
            objDbCommand.AddInParameter("SearchText", productName);
            
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "uspGetProduct", CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objProduct = new Product();
                        this.BuildModelForProduct(objDbDataReader, objProduct);
                    }

                }
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
            
            return objProduct;
        }

        public DataTable GetProduct(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            DataTable dt = new DataTable();
            
            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                dt = objDataAccess.ExecuteTable(objDbCommand, "uspGetProduct", CommandType.StoredProcedure);

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

        public string UpdateProductInformation(Product objProduct)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("ProductId", objProduct.ProductId);
            objDbCommand.AddInParameter("ProductName", objProduct.ProductName);
            objDbCommand.AddInParameter("CategoryId", objProduct.CategoryId);
            objDbCommand.AddInParameter("Stock", objProduct.Stock);
            objDbCommand.AddInParameter("MeasurementId", objProduct.MeasurementId);
            objDbCommand.AddInParameter("PurchasePrice", objProduct.PurchasePrice);
            objDbCommand.AddInParameter("SalePrice", objProduct.SalePrice);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "uspUpdateProductInformation", CommandType.StoredProcedure);

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

        public Product AddProductForSale(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            Product objProduct = new Product();
            List<Product> objProductList = new List<Product>();

            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "uspGetProduct", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objProduct = new Product();
                        this.BuildModelForProduct(objDbDataReader, objProduct);

                        objProductList.Add(objProduct);
                    }
                }
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

            return objProduct;
        }
    }
}
