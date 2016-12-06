using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POS.DAL;
using POS.Model;

namespace POS.BLL
{
    public class CategoryBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForCategory(DbDataReader objDataReader, Category objCategory)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "CategoryId":
                        if (!Convert.IsDBNull(objDataReader["CategoryId"]))
                        {
                            objCategory.CategoryId = Convert.ToInt32(objDataReader["CategoryId"]);
                        }
                        break;
                    case "CategoryName":
                        if (!Convert.IsDBNull(objDataReader["CategoryName"]))
                        {
                            objCategory.CategoryName = objDataReader["CategoryName"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public string CreateCategory(Category objCategory)
        {
            int noOfAffacted = 0;


            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("CategoryName", objCategory.CategoryName);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "uspCreateCategory", CommandType.StoredProcedure);

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

        public List<Category> GetCategoryList()
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<Category> objCategoryList = new List<Category>();
            Category objCategory;
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "uspGetCategoryForDdl", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objCategory = new Category();
                        this.BuildModelForCategory(objDbDataReader, objCategory);
                        objCategoryList.Add(objCategory);
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

            return objCategoryList;
        }
    }
}
