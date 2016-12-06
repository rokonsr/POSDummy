using System;
using System.Data;
using System.Data.Common;
using POS.DAL;
using POS.Model;

namespace POS.BLL
{
    public class UserBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForUser(DbDataReader objDataReader, User objUser)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "LoginId":
                        if (!Convert.IsDBNull(objDataReader["LoginId"]))
                        {
                            objUser.LoginId = Convert.ToInt32(objDataReader["LoginId"]);
                        }
                        break;
                    case "UserName":
                        if (!Convert.IsDBNull(objDataReader["UserName"]))
                        {
                            objUser.UserName = objDataReader["UserName"].ToString();
                        }
                        break;
                    case "Password":
                        if (!Convert.IsDBNull(objDataReader["Password"]))
                        {
                            objUser.Password = objDataReader["Password"].ToString();
                        }
                        break;
                    case "Name":
                        if (!Convert.IsDBNull(objDataReader["Name"]))
                        {
                            objUser.Name = objDataReader["Name"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public User GetLoginInfo(string userName, string password)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            User objLoginUser = null;
            objDbCommand.AddInParameter("UserName", userName);
            objDbCommand.AddInParameter("Password", password);
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "GetLoginInfo", CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objLoginUser = new User();
                        this.BuildModelForUser(objDbDataReader, objLoginUser);
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

            return objLoginUser;
        }
    }
}
