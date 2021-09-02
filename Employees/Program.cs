using System;
using System.Text.Json;
using System.IO;
using System.Text;
using System.Collections.Generic;
using FileHelper;
namespace Employees
{

    public enum Car
    {
        bmw,
        vw,
        skoda

    }


    class Employee
    {
        private static int count = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public Car Car { get; set; }
        public Employee(string name, string age, Car car)
        {
            Name = name;
            Age = age;
            Car = car;
            Id = count;
            count++;
        }

        public Employee()
        {

        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();

            while (true)
            {
                Console.Write("Enter a command: \n e - enter data \n v- view data \n f - find data \n d- delete data \n");
                string commund = Console.ReadLine();
                switch (commund)
                {
                    case "e":
                        EnterData(list);
                        break;
                    case "f":
                        FindData();
                        break;
                    case "v":
                        ViewData();
                        break;
                    case "d":
                        DeleteData();
                        break;
                    default:
                        Console.Write("Unknown command");
                        break;
                }
            }


        }
        static void EnterData(List<Employee> list)
        {

            string name;
            string age;
            int ageEmp;
            Car car;
           


            while (true)
            {
                Console.Write("Enter Name: ");
                name = Console.ReadLine().Trim();

                if (!String.IsNullOrEmpty(name))
                {

                    break;
                }
                else Console.Write("Invalid value\n");
            }
            while (true)
            {
                Console.Write("Enter Age: ");
                age = Console.ReadLine();
                if (!int.TryParse(age, out ageEmp))
                {

                    Console.Write($"Invalid value\n");
                }
                else if (ageEmp < 18 || ageEmp > 99)
                {
                    Console.Write("Invalid value\n");

                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.Write("Enter a car: ");

                if (Enum.TryParse<Car>(Console.ReadLine(), true, out car))
                {

                    break;
                }

                else Console.Write("Invalid value\n");

            }

            Employee emp = new Employee(name, age, car);
            string path = @"C:\test\test.txt";


            if (!File.Exists(path))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"C:\test");
                dirInfo.Create();
                try
                {
                    list.Add(emp);
                    string json = FileHelper.FileHelper.ReadJson(list);
                    FileHelper.FileHelper.Write(json);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }

            }
            else
            {
                string text = File.ReadAllText(@"C:\test\test.txt");
                if (!String.IsNullOrEmpty(text))
                {
                    try
                    {

                        list = FileHelper.FileHelper.ReadList(text);
                        list.Add(emp);

                        string json = FileHelper.FileHelper.ReadJson(list);
                        FileHelper.FileHelper.Write(json);
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                }
                else
                {

                    list.Add(emp);
                    string json = FileHelper.FileHelper.ReadJson(list);
                    FileHelper.FileHelper.Write(json);
                }
            }
        }


        static void ViewData()
        {
            string path = @"C:\test\test.txt";
            if (File.Exists(path))
            {
                try
                {

                    string text = File.ReadAllText(path);
                    if (!String.IsNullOrEmpty(text))
                    {
                        List<Employee> list = FileHelper.FileHelper.ReadList(text);
                        foreach (var i in list)
                        {
                            Console.Write($"{i.Name}\t{i.Age}\t{i.Car}\t \n");
                        }

                    }
                    else Console.Write("List is empty\n");


                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }

            }
            else
            {
                Console.Write("File is not exists");
            }

        }
        static void FindData()
        {
            Console.Write("Enter some information: \n");
            string inf = Console.ReadLine();
            string path = @"C:\test\test.txt";
            if (File.Exists(path))
            {
                try
                {
                    string text = File.ReadAllText(path);
                    if (!String.IsNullOrEmpty(text))
                    {
                        List<Employee> list = FileHelper.FileHelper.ReadList(text);
                        foreach (var i in list)
                        {
                            if (inf == i.Name || inf == i.Age || inf == i.Car.ToString())
                                Console.Write($"{i.Name}\t{i.Age}\t{i.Car}\t \n");

                        }

                    }
                    else Console.Write("List is empty\n");

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }

            }
            else
            {
                Console.Write("File is not exists");
            }

        }
        static void DeleteData()
        {
            Console.Write("Enter name: \n");
            string inf = Console.ReadLine();
            string path = @"C:\test\test.txt";
            if (File.Exists(path))
            {
                try
                {

                    string text = File.ReadAllText(path);
                    if (!String.IsNullOrEmpty(text))
                    {
                        List<Employee> list = FileHelper.FileHelper.ReadList(text);
                        List<Employee> newList = new List<Employee>();
                        foreach (var i in list)
                        {
                            if (inf != i.Name)
                            {
                                newList.Add(i);
                            }

                        }
                        string json = FileHelper.FileHelper.ReadJson(newList);
                        FileHelper.FileHelper.Write(json);
                    }
                    else Console.Write("List is empty\n");
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }

            }
            else
            {
                Console.Write("File is not exists");
            }
        }
       
    }


    
}