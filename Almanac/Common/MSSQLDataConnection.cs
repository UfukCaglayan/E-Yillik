using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Almanac.Common
{
    public static class MSSQLDataConnection
    {
        public static string dbConnStr = ConfigurationManager.ConnectionStrings["MSSQL"].ToString();
        private static SqlConnection dbConn = null;
        private static SqlCommand dbCmd = null;

        public static DataTable SelectDataFromDB(string Query)
        {

            dbConn = new SqlConnection(dbConnStr);
            DataTable dt = new DataTable();
            try
            {
                dbCmd = new SqlCommand(Query, dbConn);
                dbConn.Open();
                dbCmd.CommandTimeout = 10000;
                dt.Load(dbCmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                dbCmd = null;
            }
            finally
            {
                dbCmd = null;
                dbConn.Close();
            }
            return dt;
        }
        public static int SelectIntFromDB(string Query)
        {
            dbConn = new SqlConnection(dbConnStr);
            int sonuc = 0;
            try
            {
                dbCmd = new SqlCommand(Query, dbConn);
                dbConn.Open();
                sonuc = int.Parse(dbCmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                sonuc = -1;
            }
            finally
            {
                dbConn.Close();
            }
            return sonuc;
        }
        public static string SelectStringFromDB(string Query)
        {
            dbConn = new SqlConnection(dbConnStr);
            string sonuc;
            try
            {
                dbCmd = new SqlCommand(Query, dbConn);
                dbConn.Open();
                sonuc = dbCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                sonuc = "";
            }
            finally
            {
                dbConn.Close();
            }
            return sonuc;
        }
        public static bool InsertDataToDB(string Query)
        {
            dbConn = new SqlConnection(dbConnStr);
            SqlTransaction tran = null;
            bool sonuc = false;
            try
            {
                dbCmd = new SqlCommand(Query, dbConn);
                dbConn.Open();
                tran = dbConn.BeginTransaction();
                dbCmd.Transaction = tran;
                dbCmd.ExecuteNonQuery();
                tran.Commit();
                sonuc = true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
            }
            finally
            {
                dbConn.Close();
            }
            return sonuc;
        }
        public static bool UpdateDataToDB(string Query)
        {
            dbConn = new SqlConnection(dbConnStr);
            SqlTransaction tran = null;
            bool sonuc = false;
            try
            {
                dbCmd = new SqlCommand(Query, dbConn);
                dbConn.Open();
                tran = dbConn.BeginTransaction();
                dbCmd.Transaction = tran;
                dbCmd.ExecuteNonQuery();
                tran.Commit();
                sonuc = true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
            }
            finally
            {
                dbConn.Close();
            }
            return sonuc;
        }
        public static bool DeleteDataFromDB(string Query)
        {
            dbConn = new SqlConnection(dbConnStr);
            SqlTransaction tran = null;
            bool sonuc = false;
            try
            {
                dbCmd = new SqlCommand(Query, dbConn);
                dbConn.Open();
                tran = dbConn.BeginTransaction();
                dbCmd.Transaction = tran;
                dbCmd.ExecuteNonQuery();
                tran.Commit();
                sonuc = true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
            }
            finally
            {
                dbConn.Close();
            }
            return sonuc;
        }
        public static int SPGetIntValue(string Query)
        {
            dbConn = new SqlConnection(dbConnStr);
            int sonuc = 0;
            try
            {
                dbCmd = new SqlCommand(Query, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbConn.Open();
                sonuc = int.Parse(dbCmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                sonuc = -1;
            }
            finally
            {
                dbConn.Close();
            }
            return sonuc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static int SPGetIntValue(string Query, SqlParameter[] Parameters)
        {
            dbConn = new SqlConnection(dbConnStr);
            int sonuc = 0;
            try
            {
                dbCmd = new SqlCommand(Query, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbConn.Open();

                foreach (SqlParameter param in Parameters)
                    dbCmd.Parameters.Add(param);

                sonuc = int.Parse(dbCmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                sonuc = -1;
            }
            finally
            {
                dbConn.Close();
            }
            return sonuc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static void SPExecute(string Query, SqlParameter[] Parameters)
        {
            dbConn = new SqlConnection(dbConnStr);
            try
            {
                dbCmd = new SqlCommand(Query, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter param in Parameters)
                    dbCmd.Parameters.Add(param);

                dbConn.Open();

                dbCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                dbConn.Close();
            }
        }
    }
}