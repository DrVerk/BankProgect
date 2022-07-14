using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace BankProgect
{
    internal class SQLSistemClass
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataTable dt;
        DataRowView row;

        public SQLSistemClass(string datasource, string initialcatalog)
        {

        }
    }
}
