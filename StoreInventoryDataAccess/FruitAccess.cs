using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace StoreInventoryDataAccess
{
    public class FruitAccess
    {
        DataTable dt = new DataTable();
        public DataTable ReadFruitsDAL()
        {
            DataAccessLayer conn = new DataAccessLayer();
            if (ConnectionState.Closed == conn.con.State)
            {
                conn.con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM Fruits", conn.con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
            catch
            {
                throw;
            }
        }

    }
}
