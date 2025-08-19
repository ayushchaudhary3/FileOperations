using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperationsIO
{
    internal class LinqProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime date { get; set; }

        public LinqProduct() { }
        public LinqProduct(int id, string name, double price, DateTime date)
        {
            Id = id;
            Name = name;
            Price = price;
            this.date = date;
        }

        public void DisplayProduct()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Price: {Price}, Date: {date}");
        }
        public void AddProduct(LinqProduct product, string filepath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine($"{product.Id},{product.Name},{product.Price},{product.date}");
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
        public void ViewProducts(string filepath)
        {
            Console.WriteLine($"Reading products from {filepath}:");
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
