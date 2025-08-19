using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperationsIO
{
    internal class LinqPractice
    {
        List<LinqProduct> products = new List<LinqProduct>
        {
            new LinqProduct(1, "Laptop", 1200.50, DateTime.Now),
            new LinqProduct(2, "Smartphone", 800.00, DateTime.Now),
            new LinqProduct(3, "Tablet", 300.75, DateTime.Now),
            new LinqProduct(4, "Monitor", 250.00, DateTime.Now),
            new LinqProduct(5, "Keyboard", 50.00, DateTime.Now),
            new LinqProduct(6, "Mouse", 25.00, DateTime.Now),
            new LinqProduct(7, "Printer", 150.00, DateTime.Now),
            new LinqProduct(8, "Headphones", 100.00, DateTime.Now),
        };

        //From and Select
        public void BasicLinqQuery()
        {
            var result = from product in products select product;
            Console.WriteLine("\n\x1b[1mUsing Select and From:\x1b[0m");
            Console.WriteLine("\nBasic LINQ Query Result:");
            foreach (var item in result)
            {
                item.DisplayProduct();
            }
        }
        //Using Where
        public void UsingWhereLinq()
        {
            var result = from product in products
                         where product.Price > 100
                         select product;
            Console.WriteLine("\n\x1b[1mUsing Where:\x1b[0m");
            Console.WriteLine("\nProducts with Price > 100:");
            foreach (var item in result)
            {
                item.DisplayProduct();
            }
        }
        //Using OrderBy
        public void UsingOrderByLinq()
        {
            var result = from product in products
                         orderby product.Price ascending
                         select product;
            Console.WriteLine("\nUsing OrderBy:");
            Console.WriteLine("\nProducts Ordered by Price:");
            foreach (var item in result)
            {
                item.DisplayProduct();
            }
        }
        //Using GroupBy
        public void UsingGroupByLinq()
        {
            var result = from product in products
                         group product by product.Price > 100 into g
                         select new { PriceRange = g.Key ? "Above 100" : "100 or Below", Products = g };
            Console.WriteLine("\nUsing GroupBy:");
            Console.WriteLine("\nGrouped Products by Price Range:");
            foreach (var group in result)
            {
                Console.WriteLine(group.PriceRange + ":");
                foreach (var item in group.Products)
                {
                    item.DisplayProduct();
                }
            }
        }
        //Using Select or SelectMany
        public void SelectOrSelectManyLinq()
        {
            var result = from product in products
                         select new { product.Name, product.Price };
            Console.WriteLine("\nUsing Select or SelectMany:");
            Console.WriteLine("\nSelected Product Names and Prices:");
            foreach (var item in result)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price}");
            }
        }
        //Using Take or TakeWhile   
        public void UsingTakeOrTakeWhileLinq()
        {
            Console.WriteLine("\nUsing Take or TakeWhile:");
            var result = products.Take(3);
            Console.WriteLine("\nFirst 3 Products:");
            foreach (var item in result)
            {
                item.DisplayProduct();
            }
            var takeWhileResult = products.TakeWhile(p => p.Price < 500);
            Console.WriteLine("\nProducts with Price < 500:");
            foreach (var item in takeWhileResult)
            {
                item.DisplayProduct();
            }
        }
        //Using First or FirstDefault
        public void UsingFirstOrFirstDefault()
        {
            Console.WriteLine("\nUsing First or FirstDefault:");
            var productfirst = products.First(p => p.Id == 1);
            Console.WriteLine(productfirst.Name);
            var firstProduct = products.FirstOrDefault(p => p.Id == 1);
            Console.WriteLine(firstProduct.Name);
        }
        //Using Single or SingleDefault
        public void UsingSingleOrSingleDefault()
        {
            Console.WriteLine("\nUsing Single or SingleDefault:");
            try
            {
                var singleProduct = products.SingleOrDefault(p => p.Id == 1);
                Console.WriteLine("\nSingle Product with ID 1:");
                singleProduct?.DisplayProduct();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        //Using OrderBy and ThenBy
        public void UsingOrderByThenByLinq()
        {
            Console.WriteLine("\nUsing OrderBy and ThenBy:");
            var result = from product in products
                         orderby product.Price ascending, product.Name descending
                         select product;
            Console.WriteLine("\nProducts Ordered by Price (Ascending) and Name (Descending):");
            foreach (var item in result)
            {
                item.DisplayProduct();
            }
        }
        //Using GroupBy with Date
        public void UsingGroupByLinqWithDate()
        {
            var result = from product in products
                         group product by product.date.Year into g
                         select new { Year = g.Key, Products = g };
            Console.WriteLine("\nProducts Grouped by Year:");
            foreach (var group in result)
            {
                Console.WriteLine($"Year: {group.Year}");
                foreach (var item in group.Products)
                {
                    item.DisplayProduct();
                }
            }
        }
    }
   }
