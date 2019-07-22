using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using robot.Database;

namespace robot
{
    class Program
    {
        static List<ClientData> clientDataList;

        static void Main(string[] args)
        {
            loadData();
            createJSON();
        }

        static void createJSON() 
        {
            using (StreamWriter file = File.CreateText("client-data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Console.WriteLine("Creating Json...");
                serializer.Serialize(file, clientDataList);
                Console.WriteLine("Completed.");
            }
        }

        static void loadData() 
        {
            using (var db = new DB_Context())
            {
                clientDataList = db.ClientData.ToList();
            }
        }
        
    }

}
