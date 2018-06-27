using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace StoreInventoryDataAccess
{

    public class DataAccessLayer
    {
        //static string str = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString.ToString();
        //public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString.ToString());

        public SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-5HI8CS4B\SQLEXPRESS;Initial Catalog=StoreInventoryDatabase;Integrated Security=True");
        //public SqlConnection con = new SqlConnection(str);

    }
}
