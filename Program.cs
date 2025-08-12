// See https://aka.ms/new-console-template for more information
using FileOperationsIO;
using System;

Console.WriteLine("Hello, World! Welcome to File I/ O Operations");
string? filePath = "Book.txt";
string? taskFilePath = "Task.txt";
//string? filePath = "myfile.txt";


//StreamClassesDemo(filePath);


//string filePath = "people.dat";

//BinaryClassesDemo(filePath);
//FileClassDemo(filePath);
static object FileClassDemo(string filePath)
{
    while (true)
    {
        Console.WriteLine("\n--- Book App System ---");
        Console.WriteLine("1. Add New Book");
        Console.WriteLine("2. View All Books");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option (1-3): ");

        string? choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Book.AddBook(filePath);
                break;
            case "2":
                Book.ViewBooks(filePath);
                break;
            case "3":
                return Environment.Exit;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}

//TaskClassDemo(taskFilePath);
static object TaskClassDemo(string taskFilePath)
{
    while (true)
    {
        Console.WriteLine("\n--- To Do List ---");
        Console.WriteLine("1. Add New Task");
        Console.WriteLine("2. View All Tasks");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option (1-3): ");
        string? choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Tasks.AddTask(taskFilePath);
                break;
            case "2":
                Tasks.ViewTasks(taskFilePath);
                break;
            case "3":
                return Environment.Exit;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}

/*
static void StreamClassesDemo(string filePath)
{
    Console.WriteLine("Enter some text to write to file:");
    string? userInput = Console.ReadLine();

    FileWriter writer = new FileWriter(filePath);
    writer.WriteToFile(userInput);

    Console.WriteLine("\nReading from file:");
    FileReader reader = new FileReader(filePath);
    reader.ReadFromFile();
}

static void BinaryClassesDemo(string filePath)
{
    List<Person> people = new List<Person>();

    Console.WriteLine("Enter number of people:");
    int count = int.Parse(Console.ReadLine());

    for (int i = 0; i < count; i++)
    {
        Console.Write($"Enter name for person {i + 1}: ");
        string? name = Console.ReadLine();

        Console.Write($"Enter age for person {i + 1}: ");
        int age = int.Parse(Console.ReadLine());

        people.Add(new Person(name, age));
    }

    PersonWriter writer = new PersonWriter(filePath);
    writer.WritePeople(people);

    Console.WriteLine("\nReading people from file...");
    PersonReader reader = new PersonReader(filePath);
    reader.ReadPeople();
}
    */

Trainee trainee = new Trainee();
//Console.WriteLine("Enter File name with .txt extension");
//string fileName = Console.ReadLine() ?? "trainees.txt";
string fileName = "trainees.txt"; // Default file name

Console.WriteLine("Enter Trainee Name:");
trainee.Name = Console.ReadLine() ?? string.Empty;
Console.WriteLine("Enter Trainee Id:");
trainee.Id = Console.ReadLine() ?? string.Empty;
Console.WriteLine("Enter Trainee Course:");
trainee.Course = Console.ReadLine() ?? string.Empty;

//trainee.DisplayInfo();
trainee.AddTrainee(trainee, fileName);
trainee.ReadTrainee(fileName);