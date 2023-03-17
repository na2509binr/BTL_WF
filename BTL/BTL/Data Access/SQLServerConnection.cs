using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Data_Access
{
    class SQLServerConnection
    {
        private static string strcon = "server = localhost; database = BTL_WF; uid = btl; pwd = pro_bim01; MultipleActiveResultSets = true";
        public static string StringConnection
        {
            get
            {
                return strcon;
            }
        }
        public static SqlConnection Connection
        {
            get
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                return con;
            }
        }
    }
}
