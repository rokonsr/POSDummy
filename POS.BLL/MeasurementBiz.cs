using POS.DAL;
using POS.Model;
using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace POS.BLL
{
    public class MeasurementBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForMeasurement(DbDataReader objDataReader, Measurement objMeasurement)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "MeasurementId":
                        if (!Convert.IsDBNull(objDataReader["MeasurementId"]))
                        {
                            objMeasurement.MeasurementId = Convert.ToInt32(objDataReader["MeasurementId"]);
                        }
                        break;
                    case "MeasurementName":
                        if (!Convert.IsDBNull(objDataReader["MeasurementName"]))
                        {
                            objMeasurement.MeasurementName = objDataReader["MeasurementName"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public string CreateMeasurement(Measurement objMeasurement)
        {
            int noOfAffacted = 0;


            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("MeasurementName", objMeasurement.MeasurementName);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "uspCreateMeasurement", CommandType.StoredProcedure);

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

        public List<Measurement> GetMeasurementList()
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<Measurement> objMeasurementList = new List<Measurement>();
            Measurement objMeasurement;
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "uspGetMeasurementForDdl", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objMeasurement = new Measurement();
                        this.BuildModelForMeasurement(objDbDataReader, objMeasurement);
                        objMeasurementList.Add(objMeasurement);
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

            return objMeasurementList;
        }
    }
}
