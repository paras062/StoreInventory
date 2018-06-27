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
        DataAccessLayer conn = new DataAccessLayer();
        SqlCommand cmd = new SqlCommand();
        //Select
        public DataTable ReadFruitsDAL()
        {
            //DataAccessLayer conn = new DataAccessLayer();
            if (ConnectionState.Closed == conn.con.State)
            {
                conn.con.Open();
            }

            //SqlCommand cmd = new SqlCommand("SELECT * FROM Fruits", conn.con);
            cmd.CommandText = "SELECT * FROM Fruits";
            cmd.Connection = conn.con;

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

        //Insert
        public int InsertFruitsDAL(string fruitName, string fruitQuantity)
        {
            if (ConnectionState.Closed == conn.con.State)
            {
                conn.con.Open();
            }

            cmd.CommandText = "INSERT INTO Fruits (Name, Quantity) VALUES (@fName, @fQuantity)";
            cmd.Parameters.AddWithValue("@fName", fruitName);
            cmd.Parameters.AddWithValue("@fQuantity", fruitQuantity);

            cmd.Connection = conn.con;

            //execute command
            int rowCount = cmd.ExecuteNonQuery();
            return rowCount;
        }

        //Update

        //Update only Fruit Name
        public int UpdateOnlyFruitsNameDAL(string id, string fruitName)
        {

            if (ConnectionState.Closed == conn.con.State)
            {
                conn.con.Open();
            }

            cmd.CommandText = "UPDATE Fruits SET Name = @fName WHERE ID = @id";
            cmd.Parameters.AddWithValue("@fName", fruitName);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.Connection = conn.con;

            //execute command
            int rowCount = cmd.ExecuteNonQuery();
            return rowCount;
        }

        //Update only Fruit Quantity
        public int UpdateOnlyFruitsQuantityDAL(string id, string fruitQuanitiy)
        {
            if (ConnectionState.Closed == conn.con.State)
            {
                conn.con.Open();
            }

            cmd.CommandText = "UPDATE Fruits SET Quantity = @fQuantity WHERE ID = @id";
            cmd.Parameters.AddWithValue("@fQuantity", fruitQuanitiy);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.Connection = conn.con;

            //execute command
            int rowCount = cmd.ExecuteNonQuery();
            return rowCount;
        }

        //Update Fruit Name and Fruit Quantity
        public int UpdateFruitNameAndFruitQuantity(string id, string fruitName, string fruitQuantity)
        {
            if (ConnectionState.Closed == conn.con.State)
            {
                conn.con.Open();
            }

            cmd.CommandText = "UPDATE Fruits SET Name = @fName, Quantity = @fQuantity WHERE ID = @id";
            cmd.Parameters.AddWithValue("@fName", fruitName);
            cmd.Parameters.AddWithValue("@fQuantity", fruitQuantity);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.Connection = conn.con;

            //execute command
            int rowCount = cmd.ExecuteNonQuery();
            return rowCount;
        }

        //Delete Records
        public int DeleteFruitsDataDAL(string id)
        {
            if (ConnectionState.Closed == conn.con.State)
            {
                conn.con.Open();
            }

            cmd.CommandText = "DELETE FROM Fruits WHERE id=@ID";
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.Connection = conn.con;

            //execute command
            int rowCount = cmd.ExecuteNonQuery();
            return rowCount;
        }
    }
}
