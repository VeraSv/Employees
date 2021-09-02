using System;
using Employees;
namespace FileHelper
{  
public class FileHelper
{
	
        static List<Employee> ReadList(string text)
        {
            return (JsonSerializer.Deserialize<List<Employee>>(text));
        }
        internal static string ReadJson(List<Employee> list)
        {
            return (JsonSerializer.Serialize(list));
        }
        static void Write(string json)
        {
            using (StreamWriter file = new StreamWriter(@"C:\test\test.txt"))
            {
                file.Write(json);
            }
        }
    
}
}