using System;
using System.Data;
using System.IO;
using System.Text;

namespace StoreInventory
{
    class Program
    {

        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory().ToString();
            string inputFile = currentDirectory + @"\Files\Input\Fruits.txt";
            string[] fileData;
            string[] data;
            string fruitName = string.Empty;
            int fruitQuantity;
            DataTable FruitInventory = new DataTable();
            FruitInventory.Columns.Add("Fruits Quantity", typeof(string));
            FruitInventory.Columns.Add("Quantity", typeof(int));

            //To check if the provided input file path is correct 
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

            /*
             * As SortDataTable method is non-static method whereas Main is a static member, so inorder to access non-static member
             * from a static member we need to create reference. We can't call instance method from inside the static member.
           */
            Program p = new Program();
            p.SortDataTable(FruitInventory, 3);


        }

        //Method to sort the datatable.
        public void SortDataTable(DataTable dt, int count)
        {
            DataTable resultData = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            string formattedString = string.Empty;
            try
            {
                DataView dv = dt.DefaultView;
                dv.Sort = "Quantity DESC";
                dt = dv.ToTable();

                resultData = dt.Clone();
                for (int i = 0; i < count; i++)
                {
                    resultData.ImportRow(dt.Rows[i]);
                }

                foreach (DataRow dataRow in resultData.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        stringBuilder.Append(item);
                        stringBuilder.Append(" ");
                    }
                    stringBuilder.AppendLine();
                    formattedString = stringBuilder.ToString();
                }

                Console.WriteLine(formattedString);

                //Method called to write content to file.
                WriteResultsToFile(formattedString);
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception is: " + Ex.GetBaseException());
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Stack Trace: " + Ex.StackTrace);
            }
        }

        //write data into result file
        public static void WriteResultsToFile(string content)
        {
            string currentDirectory = Directory.GetCurrentDirectory().ToString();
            string outputFile = currentDirectory + @"\Files\Output\Result.txt";
            /*
             * The File.Create method creates the file and opens a FileStream on the file. 
             * So your file is already open. You don't really need the file.Create method at all:
             * The boolean in the StreamWriter constructor will cause the contents to be appended if the file exists.
             */
            using (StreamWriter sw = new StreamWriter(outputFile, true))
            {
                sw.WriteLine(content);
                sw.Close();
            }
        }


    }
}
