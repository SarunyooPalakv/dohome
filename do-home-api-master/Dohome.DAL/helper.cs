using Dohome.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dohome.DAL
{
    public class helper : BaseConnection
    {
        public List<T> ExecuteQuery<T>(string sql, object paramlist, CommandType commandType) where T : new()
        {
            List<T> result = new List<T>();
            using (IDbConnection conn = GetOpenConnection())
            {
                try
                {
                    result = conn.Query<T>(sql, paramlist, null, false, null, commandType).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
            return result;
        }
        public string ExecuteQuery(string sql, object paramlist, CommandType commandType)
        {
            string result = string.Empty;
            using (IDbConnection conn = GetOpenConnection())
            {
                try
                {
                    result = conn.Query<string>(sql, paramlist, null, false, null, commandType).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
            return result;
        }
        public string ExecuteListQuery(string sql, object paramlist, CommandType commandType)
        {
            string result = string.Empty;
            using (IDbConnection conn = GetOpenConnection())
            {
                try
                {
                    result = string.Join(",", conn.Query<DataTable>(sql, paramlist, null, false, null, commandType).ToList());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
            return result;
        }
        public int ExecuteScalar(string sql, object paramlist)
        {
            int result = 0;
            using (IDbConnection conn = GetOpenConnection())
            {
                try
                {
                    result = conn.ExecuteScalar<int>(sql, paramlist);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
            return result;
        }
        public bool ExecuteNonQuery(string sql, object paramlist, CommandType commandType)
        {
            bool result = false;
            using (IDbConnection conn = GetOpenConnection())
            {
                IDbTransaction transaction = null;
                try
                {
                    transaction = conn.BeginTransaction();
                    if (conn.Execute(sql, paramlist, transaction, null, commandType) > 0) result = true;
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                        transaction.Dispose();
                    }
                }
            }
            return result;
        }
        public virtual string EncodePassword(string password, string _validationKey)
        {
            string encodedPassword = password;
            HMACSHA1 hash = new HMACSHA1();
            hash.Key = HexToByte(_validationKey);
            encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
            return encodedPassword;
        }
        public static byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[(hexString.Length / 2)];
            for (int i = 0; (i < returnBytes.Length); i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring((i * 2), 2), 16);
            return returnBytes;
        }
        public DateTime ConvertStringToDateTime(string value)
        {
            return DateTime.ParseExact(value, "dd/MM/yyyy", new System.Globalization.CultureInfo("en-EN"));
        }
    }
}
