using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace API.Utils
{
    public class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"172.20.61.86";

            string database = "TTX_PORTAL_BG";
            string username = "qthtmonitor";
            string password = "Qtht@2022";

            return SQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}