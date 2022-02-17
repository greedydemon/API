using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using API.Models;

namespace API.Utils
{
    public class DBUtils
    {
        public string datasource = string.Empty;

        public string database = string.Empty;
        public string username = string.Empty;
        public string password = string.Empty;
        readonly OleDbConnection myConnection = new OleDbConnection();
        readonly string myConnectionString = @"Provider=Microsoft.ACE.Oledb.12.0;
                           Data Source= C:\Users\Tai\Documents\IISExpress\APIMonitor.accdb";
        public DBUtils()
        {
            GetDBConnection();
        }

        public bool GetAllConnectInfor()
        {
            try
            {
                myConnection.ConnectionString = myConnectionString;
                myConnection.Open();
                string query = "select * from SqlInfor";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    datasource = reader[0].ToString();
                    database = reader[1].ToString();
                    username = reader[2].ToString();
                    password = reader[3].ToString();
                }
                myConnection.Close();
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }
        public List<CategoryAccess> GetAllCategoryAccess()
        {
            try
            {
                List<CategoryAccess> lstCategoryAccess = new List<CategoryAccess>();
                myConnection.ConnectionString = myConnectionString;
                myConnection.Open();
                string query = "select * from CategoryName";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CategoryAccess catergoryAccess = new CategoryAccess();
                    catergoryAccess.ID = Int32.Parse(reader[0].ToString());
                    catergoryAccess.Title = reader[1].ToString();
                    catergoryAccess.Department = reader[2].ToString();
                    lstCategoryAccess.Add(catergoryAccess);
                }
                myConnection.Close();
                return lstCategoryAccess;
            }

            catch (Exception)
            {
                return new List<CategoryAccess>();
            }
        }



        public SqlConnection GetDBConnection()
        {
            GetAllConnectInfor();
            //List<CategoryAccess> _lstcater = GetAllCategoryAccess();
            //string datasource = @"172.20.61.86";

            //string database = "TTX_PORTAL_BG";
            //string username = "qthtmonitor";
            //string password = "Qtht@2022";

            return SQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}