using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperationsIO
{
    public class Book
    {

        public Book() { }

        public Book(string name, string author) { }

        public static void AddBook(string filePath)
        {
            try
            {
                Console.Write("Enter Book Title: ");
                string? title = Console.ReadLine();

                Console.Write("Enter Author Name: ");
                string? author = Console.ReadLine();

                string? bookEntry = $"{title},{author}";

                File.AppendAllText(filePath, bookEntry + Environment.NewLine);
                Console.WriteLine("Book added successfully.");

            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while writing to the file: " +
                    ex.Message);
            }
        }

        public static void ViewBooks(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No books found.");
                    //return;
                }

                string[] books = File.ReadAllLines(filePath);
                Console.WriteLine("\nAvailable Books:");

                foreach (string book in books)
                {
                    string[] parts = book.Split(',');
                    Console.WriteLine($"Title: {parts[0]}, Author: {parts[1]}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while reading the file: " + ex.Message);
            }
        }

    }
}
