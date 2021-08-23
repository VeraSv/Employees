using System;
using System.Text.Json;
using System.IO;
using System.Text;
using System.Collections.Generic;

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
        public string Car { get; set; }
        public Employee(string name, string age,string car)
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
                Console.Write("Enter a commund: \n e - enter data \n v- view data \n f - find data \n d- delete data \n");
                string commund = Console.ReadLine();
                switch (commund)
                {
                    case "e":
                        enterData(list);
                        break;
                    case "f":
                        findData();
                        break;
                    case "v":
                        viewData();
                        break;
                    case "d":
                        deleteData();
                        break;
                    default:
                        Console.Write("Unknown commund");
                        break;
                }
            }


        }
        static void enterData(List<Employee> list)
        {

            string name;
            string age;
            int ageEmp;
            Car car;
            string carEmp;


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

                carEmp = Console.ReadLine();
                if (Enum.TryParse<Car>(carEmp, true, out car))
                {

                    break;
                }

                else Console.Write("Invalid value\n");

            }

            Employee emp = new Employee(name,  age, carEmp );

            string path = @"C:\test";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                try
                {

                    list.Add(emp);
                    string json = JsonSerializer.Serialize(list);
                   
                    using (StreamWriter file = new StreamWriter(@"C:\test\test.txt"))
                    {
                        file.Write(json);
                    }
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
                       
                        list = JsonSerializer.Deserialize<List<Employee>>(text);
                       

                        list.Add(emp);
                       
                        string json = JsonSerializer.Serialize(list);
                        
                        
                        using (StreamWriter file = new StreamWriter(@"C:\test\test.txt"))
                        {
                            file.Write(json);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                }
                else
                {
                    
                    list.Add(emp);
                    string json = JsonSerializer.Serialize(list);
                    using (StreamWriter file = new StreamWriter(@"C:\test\test.txt"))
                    {
                        file.Write(json);
                    }
                }
            }
        }


        static void viewData()
        {
            string path = @"C:\test\test.txt";
            if (File.Exists(path))
            {
                try
                {

                    string text = File.ReadAllText(path);
                    if (!String.IsNullOrEmpty(text))
                    {
                        List<Employee> list = JsonSerializer.Deserialize<List<Employee>>(text);
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
        static void findData()
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
                        List<Employee> list = JsonSerializer.Deserialize<List<Employee>>(text);
                        foreach (var i in list)
                        {
                            if (inf == i.Name || inf == i.Age || inf == i.Car)
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
        static void deleteData()
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
                        List<Employee> list = JsonSerializer.Deserialize<List<Employee>>(text);
                        foreach (var i in list)
                        {
                            if (inf == i.Name)
                            {
                                list.Remove(i);
                                string json = JsonSerializer.Serialize(list);                               
                                using (StreamWriter file = new StreamWriter(@"C:\test\test.txt"))
                                {
                                    file.Write(json);
                                }

                            }
                            
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

    }
}

