using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreInventoryDataAccess;
using System.Data;


namespace StoreInventoryBusinessLayer
{
    public class BusinessLayer
    {
        public DataTable dt = new DataTable();
        FruitAccess objFA = new FruitAccess();
        //Select
        public DataTable ReadFruitsBAL()
        {
            try
            {

                return objFA.ReadFruitsDAL();
            }
            catch
            {

                throw;
            }
        }

        //Insert
        public int InsertFruitsBAL(string fruitName, string fruitQuantity)
        {
            try
            {
                int rowCount = objFA.InsertFruitsDAL(fruitName, fruitQuantity);
                return rowCount;
            }
            catch
            {
                throw;
            }
        }

        //Update

        //Update only Fruit Name
        public int UpdateOnlyFruitsNameBAL(string id, string fruitName)
        {
            try
            {
                int rowCount = objFA.UpdateOnlyFruitsNameDAL(id, fruitName);
                return rowCount;
            }
            catch
            {
                throw;
            }
        }

        //Update only Fruit Quantity
        public int UpdateOnlyFruitsQuantityBAL(string id, string fruitQuantity)
        {
            try
            {
                int rowCount = objFA.UpdateOnlyFruitsQuantityDAL(id, fruitQuantity);
                return rowCount;
            }
            catch
            {
                throw;
            }
        }

        //Update Fruit Name and Fruit Quantity
        public int UpdateFruitNameAndFruitQuantityBAL(string id, string fruitName, string fruitQuantity)
        {
            try
            {
                int rowCount = objFA.UpdateFruitNameAndFruitQuantity(id, fruitName, fruitQuantity);
                return rowCount;
            }
            catch
            {
                throw;
            }
        }

        //Delete Fruit Data
        public int DeleteFruitsDataBAL(string id)
        {
            try
            {
                int rowCount = objFA.DeleteFruitsDataDAL(id);
                return rowCount;
            }
            catch
            {
                throw;
            }
        }

    }
}