﻿using System;
using System;
using System.Text.Json;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Employees;
namespace FileHelper
{  
public class FileHelper
{
	public FileHelper()
	{
        
    }
       internal static List<Employee> ReadList(string text)
        {
            return (JsonSerializer.Deserialize<List<Employee>>(text));
        }
        internal static string ReadJson(List<Employee> list)
        {
            return (JsonSerializer.Serialize(list));
        }
        internal static void Write(string json)
        {
            using (StreamWriter file = new StreamWriter(@"C:\test\test.txt"))
            {
                file.Write(json);
            }
        }
    }
}