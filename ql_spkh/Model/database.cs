using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ql_spkh.Model
{
    public class database
    {
        private string chuoiKN = @"Data Source=TRANKHOA\SQLEXPRESS;Initial Catalog=ql_da_nckh;Integrated Security=True;";
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private DataTable dt = null;

        public database()
        {
            try
            {
                conn = new SqlConnection(chuoiKN);
            }
            catch (Exception e)
            {
                logError.log(e.Message);
            }
        }

        public DataTable Login(string sql, List<parameter> lst)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var param in lst)
                {
                    cmd.Parameters.AddWithValue(param.key, param.value);
                }
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                if (dt.Rows.Count == 0 || dt.Rows.Count > 1)
                {
                    return null;
                }

                return dt;

            }
            catch (Exception e)
            {
                logError.log(e.Message);
                return null;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                dt.Dispose();
            }
        }

        public DataTable QuerySQL(string sql)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                foreach (DataColumn column in dt.Columns)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0][column.ColumnName]?.ToString()))
                    {
                        return dt;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                logError.log(e.Message);
                return null;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                dt.Dispose();
            }
        }
        public int QuerySQL_No(string sql)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                var rs = cmd.ExecuteNonQuery();
                return (int)rs;
            }
            catch (Exception e)
            {
                logError.log(e.Message);
                return 0;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();;
            }
        }

        public int Query_P(string sql, List<parameter> lstPara)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn); 
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var p in lstPara) 
                {
                    cmd.Parameters.AddWithValue(p.key, p.value); 
                }
                var rs = cmd.ExecuteNonQuery(); 
                return (int)rs;
            }
            catch (Exception ex)
            {
                logError.log(ex.Message);
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }
        public byte[] GetNoiDung(int idCauHoi)
        {
            byte[] noiDungBytes = null;
            string sql = "SELECT projectcontent FROM projects WHERE projectid = " + idCauHoi;
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                noiDungBytes = (byte[])cmd.ExecuteScalar();
                return noiDungBytes;
            }
            catch (Exception ex)
            {
                logError.log(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }

        }
        public byte[] GetNoiDung_V(int idCauHoi)
        {
            byte[] noiDungBytes = null;
            string sql = "SELECT projectnew FROM projectversions WHERE versionid = " + idCauHoi;
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                noiDungBytes = (byte[])cmd.ExecuteScalar();
                return noiDungBytes;
            }
            catch (Exception ex)
            {
                logError.log(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }

        }

        public void ActivityLog(string type,string detail)
        {
            try
            {
                conn.Open();
                string sql = "INSERT INTO activitylog VALUES(1,N'" + type + "',getdate(),N'" + detail + "')";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logError.log(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
