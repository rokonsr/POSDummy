﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web.Services;
using POS.DAL;

namespace POS.CategoryUI
{
    /// <summary>
    /// Summary description for CheckExistingCategory
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CheckExistingCategory : System.Web.Services.WebService
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        [WebMethod]
        public List<string> CheckCategory(string categoryName)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objProductList = new List<string>();

            objDbCommand.AddInParameter("SearchText", categoryName);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "uspGetCategoryBySearch", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objProductList.Add(objDbDataReader["CategoryName"].ToString());
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
            return objProductList;
        }
    }
}
