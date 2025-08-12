using System;
using System.IO;

namespace FileOperationsIO
{
    public class Tasks
    {
        public Tasks() { }

        public Tasks(string description, string dueDate) { }

        public static void AddTask(string filePath)
        {
            try
            {
                Console.Write("Enter Task Description: ");
                string? description = Console.ReadLine();

                Console.Write("Enter Due Date: ");
                string? dueDate = Console.ReadLine();

                string? taskEntry = $"{description},{dueDate}";

                File.AppendAllText(filePath, taskEntry + Environment.NewLine);
                Console.WriteLine("Task added successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
            }
        }

        public static void ViewTasks(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No tasks found.");
                    return;
                }

                string[] tasks = File.ReadAllLines(filePath);
                Console.WriteLine("\nAvailable Tasks:");

                foreach (string task in tasks)
                {
                    string[] parts = task.Split(',');
                    Console.WriteLine($"Description: {parts[0]}, Due Date: {parts[1]}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while reading the file: " + ex.Message);
            }
        }
    }
}