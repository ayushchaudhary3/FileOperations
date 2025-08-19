using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperationsIO
{
    internal class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product() { }
        public Product(int productId, string name, decimal price)
        {
            ProductID = productId;
            Name = name;
            Price = price;
        }
        public void AddProduct(Product product, string filepath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine($"ID: {product.ProductID}, Name: {product.Name}, Price: {product.Price}");
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

        public void ShowProducts(string filepath)
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
