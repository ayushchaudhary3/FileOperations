using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperationsIO
{
    internal class Cafe
    {
        public string Name { get; set; }
        public int OrderNumber { get; set; }
        public string OrderDetails { get; set; }
        public Cafe() { }
        public Cafe(string name, int orderNumber, string orderDetails)
        {
            Name = name;
            OrderNumber = orderNumber;
            OrderDetails = orderDetails;
        }

        public void AddOrder(Cafe cafe, string filepath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine($"{cafe.Name},{cafe.OrderNumber},{cafe.OrderDetails}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public void ReadOrders(string filepath)
        {
            Console.WriteLine($"Reading orders from {filepath}:");
            try
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine("File not found: " + fnfEx.Message);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine("An error occurred while reading the file: " + ioEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
