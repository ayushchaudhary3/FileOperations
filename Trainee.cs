using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperationsIO
{
    internal class Trainee
    {
        public string Name { get; set; }
        public string Id { get; set; } = string.Empty;
        public string Course { get; set; }

        public Trainee() { }
        public Trainee(string name, string id, string course)
        {
            Name = name;
            Id = id;
            Course = course;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, ID: {Id}, Course: {Course}");
        }
        public void AddTrainee(Trainee trainee, string filepath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine($"{trainee.Name},{trainee.Id},{trainee.Course}");
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
        public void ReadTrainee(string filepath)
        {
            Console.WriteLine($"Reading trainees from {filepath}:");
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
