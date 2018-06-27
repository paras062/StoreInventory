using System;
using System.Data;
using System.IO;
using System.Text;
using StoreInventoryBusinessLayer;

namespace StoreInventory
{
    class Program
    {

        static void Main(string[] args)
        {
            string flag = string.Empty;
            bool value = true;
            Console.WriteLine("Select from the following");
            Console.WriteLine("1. View Data");
            Console.WriteLine("2. Insert Data");
            Console.WriteLine("3. Update Existing Data");
            Console.WriteLine("4. Delete Existing Data");
            Console.WriteLine(Environment.NewLine);

            while (value)
            {
                Console.WriteLine("Please Enter Your Choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                ProcessInput(choice);
                Console.WriteLine("Do you wish to continue? Y/N");
                flag = Console.ReadLine().ToUpper();

                value = (flag == "YES" || flag == "Y") ? true : false;
                //if (flag == "YES" || flag == "Y")
                //{
                //    value = true;
                //}
                //else
                //{
                //    value = false;
                //}
            }
        }

        //Process Input
        static private void ProcessInput(int choice)
        {
            switch (choice)
            {
                case 1:
                    ReadData();
                    break;
                case 2:
                    InsertData();
                    break;
                case 3:
                    UpdateData();
                    break;
                case 4:
                    DeleteData();
                    break;
                default:
                    Console.WriteLine("Please select the correct choice!");
                    break;
            }
        }
        //Method to Read Data
        static private void ReadData()
        {
            BusinessLayer objBL = new BusinessLayer();
            StringBuilder stringBuilder = new StringBuilder();
            string formattedString = string.Empty;


            DataTable dt = objBL.ReadFruitsBAL();
            foreach (DataColumn column in dt.Columns)
            {
                Console.Write(column.ColumnName);
                Console.Write(" ");
            }
            Console.WriteLine(Environment.NewLine);
            foreach (DataRow rows in dt.Rows)
            {
                foreach (var item in rows.ItemArray)
                {
                    stringBuilder.Append(item);
                    stringBuilder.Append(" ");
                }
                stringBuilder.AppendLine();
                formattedString = stringBuilder.ToString();
            }

            Console.WriteLine(formattedString);
        }

        //Method to Insert Data
        static private void InsertData()
        {
            Console.WriteLine("Enter Fruit Name: ");
            string fruitName = Console.ReadLine();
            Console.WriteLine("Enter Fruit Quantity");
            string fruitQuantity = Console.ReadLine();
            BusinessLayer objBL = new BusinessLayer();
            int rowCount = objBL.InsertFruitsBAL(fruitName, fruitQuantity);
            if (rowCount > 0)
            {
                Console.WriteLine("Record Added");
            }
            else
            {
                Console.WriteLine("Error while inserting data!!!");
            }
        }

        //Method to Update Data
        static private void UpdateData()
        {
            ReadData();
            Console.WriteLine("Choose Fruit ID you want to update: ");
            string id = Console.ReadLine();
            string fruitName = string.Empty;
            string fruitQuantity = string.Empty;
            BusinessLayer objBL = new BusinessLayer();
            Console.WriteLine("What details you want to update? Please select your choice:");
            Console.WriteLine("1. Fruit Name");
            Console.WriteLine("2. Quantity");
            Console.WriteLine("3. Both");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("Enter Fruit Name: ");
                fruitName = Console.ReadLine();
                int rowCount = objBL.UpdateOnlyFruitsNameBAL(id, fruitName);
                if (rowCount > 0)
                {
                    Console.WriteLine("Record Updated");
                }
                else
                {
                    Console.WriteLine("Error while updating data!!!");
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter Fruit Quantity: ");
                fruitQuantity = Console.ReadLine();
                int rowCount = objBL.UpdateOnlyFruitsQuantityBAL(id, fruitQuantity);
                if (rowCount > 0)
                {
                    Console.WriteLine("Record Updated");
                }
                else
                {
                    Console.WriteLine("Error while updating data!!!");
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("Enter Fruit Name");
                fruitName = Console.ReadLine();
                Console.WriteLine("Enter Fruit Quantity");
                fruitQuantity = Console.ReadLine();
                int rowCount = objBL.UpdateFruitNameAndFruitQuantityBAL(id, fruitName, fruitQuantity);
                if (rowCount > 0)
                {
                    Console.WriteLine("Record Updated");
                }
                else
                {
                    Console.WriteLine("Error while updating data!!!");
                }
            }



            fruitQuantity = Console.ReadLine();
        }

        //Delete Data
        static private void DeleteData()
        {
            ReadData();
            Console.WriteLine("Choose Fruit ID you want to delete.");
            string id = Console.ReadLine();
            BusinessLayer objBL = new BusinessLayer();
            int rowCount = objBL.DeleteFruitsDataBAL(id);
            if (rowCount > 0)
            {
                Console.WriteLine("Record Removed");
            }
            else
            {
                Console.WriteLine("Error while removing record");
            }

        }
        //Console.WriteLine(objBL.ReadFruitsBAL());

        /*
        string currentDirectory = Directory.GetCurrentDirectory().ToString();
        string inputFile = currentDirectory + @"\Files\Input\Fruits.txt";
        string[] fileData;
        string[] data;
        string fruitName = string.Empty;
        int fruitQuantity;
        DataTable FruitInventory = new DataTable();
        FruitInventory.Columns.Add("Fruits Quantity", typeof(string));
        FruitInventory.Columns.Add("Quantity", typeof(int));
        */
        //To check if the provided input file path is correct
        /*
        try
        {
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("ERROR! Either file not present at the location or the provided input file path is not correct");
            }
            else
            {
                //fileData array will store data coming from the Fruits.txt file.
                fileData = File.ReadAllLines(inputFile);
                //split data from fileData array and store it in data array
                for (int i = 0; i < fileData.Length; i++)
                {
                    data = fileData[i].ToString().Split(' ');
                    fruitName = data[0];
                    fruitQuantity = Convert.ToInt32(data[1]);
                    //Console.WriteLine("Fruit Name: " + fruitName + " Fruit Quantity: " + fruitQuantity);

                    for (int rowIndex = 1; rowIndex < data.GetLength(0); rowIndex++)
                    {
                        FruitInventory.Rows.Add(fruitName, fruitQuantity);
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Exception is: " + Ex.GetBaseException());
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Stack Trace: " + Ex.StackTrace);
        }
        */
        /*
         * As SortDataTable method is non-static method whereas Main is a static member, so inorder to access non-static member
         * from a static member we need to create reference. We can't call instance method from inside the static member.
       */
        /*
         Program p = new Program();
         p.SortDataTable(FruitInventory, 3);
         */

        ///<summary
        /// To Read Data From DataBase
        ///</summary>
    }

    //Method to sort the datatable.
    //public void SortDataTable(DataTable dt, int count)
    // {
    //     DataTable resultData = new DataTable();
    //     StringBuilder stringBuilder = new StringBuilder();
    //     string formattedString = string.Empty;
    //     try
    //     {
    //         DataView dv = dt.DefaultView;
    //         dv.Sort = "Quantity DESC";
    //         dt = dv.ToTable();

    //         resultData = dt.Clone();
    //         for (int i = 0; i < count; i++)
    //         {
    //             resultData.ImportRow(dt.Rows[i]);
    //         }

    //         foreach (DataRow dataRow in resultData.Rows)
    //         {
    //             foreach (var item in dataRow.ItemArray)
    //             {
    //                 stringBuilder.Append(item);
    //                 stringBuilder.Append(" ");
    //             }
    //             stringBuilder.AppendLine();
    //             formattedString = stringBuilder.ToString();
    //         }

    //         Console.WriteLine(formattedString);

    //         //Method called to write content to file.
    //         //WriteResultsToFile(formattedString);
    //     }
    //     catch (Exception Ex)
    //     {
    //         Console.WriteLine("Exception is: " + Ex.GetBaseException());
    //         Console.WriteLine(Environment.NewLine);
    //         Console.WriteLine("Stack Trace: " + Ex.StackTrace);
    //     }
    // }

    // //write data into result file
    // public static void WriteResultsToFile(string content)
    // {
    //     string currentDirectory = Directory.GetCurrentDirectory().ToString();
    //     string outputFile = currentDirectory + @"\Files\Output\Result.txt";
    //     /*
    //      * The File.Create method creates the file and opens a FileStream on the file. 
    //      * So your file is already open. You don't really need the file.Create method at all:
    //      * The boolean in the StreamWriter constructor will cause the contents to be appended if the file exists.
    //      */
    //     using (StreamWriter sw = new StreamWriter(outputFile, true))
    //     {
    //         sw.WriteLine(content);
    //         sw.Close();
    //     }
    // }


}
