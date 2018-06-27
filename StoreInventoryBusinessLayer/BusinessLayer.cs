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

        public DataTable ReadFruitsBAL()
        {
            try
            {
                FruitAccess objFA = new FruitAccess();
                return objFA.ReadFruitsDAL();
            }
            catch
            {

                throw;
            }
        }
    }
}