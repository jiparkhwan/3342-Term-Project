using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Utilities;

namespace ClassLibrary
{
    public class StoredProcedures
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string strSQL;

        public DataSet getAllActors()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAllActors";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }
    }
}
