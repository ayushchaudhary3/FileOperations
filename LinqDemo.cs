using FileOperationsIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperationsIO
{
    internal class LinqDemo
    {

        int[] numbers = { 101, 122, 365, 14, 95, 86, 57, 78, 89, 10 };

        List<Trainee> trainees = new List<Trainee>
        {
            new Trainee("John Doe", "T001", "C# Programming"),
            new Trainee("Jane Smith", "T002", "Java Programming"),
            new Trainee("Alice Johnson", "T003", "Python Programming"),
            new Trainee("Bob Brown", "T004", "Web Development"),
            new Trainee("Charlie White", "T005", "Data Science"),
            new Trainee("David Green", "T006", "C# Programming"),
            new Trainee("Eve Black", "T007", "Java Programming"),
            new Trainee("Frank Blue", "T008", "Python Programming"),
            new Trainee("Grace Yellow", "T009", "Web Development")
        };

        ArrayList arrayList = new ArrayList
        {
            101, 122, 365, 14, 95, 86, 57, 78, 89, 10,
            "John Doe", "Jane Smith", "Alice Johnson"
        };


        // Linq queries

        public void LinqOfTypeArraylist()
        {

            var names = arrayList.OfType<string>();
            var numbers = arrayList.OfType<int>();
            Console.WriteLine("\nNames are :");
            foreach (var name in names)
            {
                Console.Write(name + "  ");

            }
            Console.WriteLine("\nNumbers are:");

            foreach (var no in numbers)
            {
                Console.Write(no + " ");
            }
        }

        public void BasicLinqQuery()
        {
            var result = from no in numbers select no;
            Console.WriteLine("From and Select: ");

            foreach (var n in result)
            {
                Console.Write(n + "  ");
            }
            Console.WriteLine();
        }

        public void UsingWhereLinq()
        {
            Console.WriteLine("\nusing where clause in LINQ:");
            var result = from no in numbers
                         where no > 70
                         select no;

            foreach (var n in result)
            {
                Console.Write(n + " ");
            }
        }

        public void UsingOrderByLinq()
        {
            Console.WriteLine("\n\nusing OrderBy clause in LINQ:");
            var result = from trainee in trainees
                         orderby trainee.Name ascending
                         select trainee;
            foreach (var t in result)
            {
                Console.WriteLine($"Name: {t.Name}, Id: {t.Id}, Course: {t.Course}");
            }
        }
        public void TakeLinq()
        {
            Console.WriteLine("Using Take in LINQ");
            var result = numbers.Take(5);
            foreach (var n in result)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            var takeresult = numbers.TakeWhile(n => n > 100);

            Console.WriteLine("Using TakeWhile in LINQ");
            foreach (var n in takeresult)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }
        public void GroupByLinq()
        {
            Console.WriteLine("Using GroupBy in LINQ");
            var groupedTrainees = trainees.GroupBy(t => t.Course);
            foreach (var group in groupedTrainees)
            {
                Console.WriteLine($"Course: {group.Key}");
                foreach (var trainee in group)
                {
                    Console.WriteLine($"  Name: {trainee.Name}, Id: {trainee.Id}");
                }
            }
        }
        public void OrderByThenByLinq()
        {
            Console.WriteLine("Using OrderBy and ThenBy in LINQ");
            /* var result = from trainee in trainees
                          orderby trainee.Name ascending, trainee.Id descending
                          select trainee;*/
            var result = trainees.OrderBy(t => t.Name).ThenByDescending(t => t.Id);
            foreach (var t in result)
            {
                Console.WriteLine($"Name: {t.Name}, Id: {t.Id}, Course: {t.Course}");
            }
        }

        public void FirstOrFirstDefault()
        {
            var trainee = trainees.First(t => t.Id == "T001");
            Console.WriteLine(trainee.Name);
            var tn = trainees.FirstOrDefault(t => t.Id == "T009");
            Console.WriteLine(tn.Name);
        }

        public void SingleOrSingleDefault()
        {
            var stn = trainees.Single(s => s.Course == "Data Science");
            Console.WriteLine(stn.Course);
            var sdtn = trainees.SingleOrDefault(t => t.Course == "Java");
            Console.WriteLine(sdtn.Course); // This will throw an exception if no match is found
        }
    }
}