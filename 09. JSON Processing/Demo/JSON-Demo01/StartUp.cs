namespace JSON_Demo01
{
    using System;
    using System.IO;
    using Newtonsoft.Json;
    using System.Text.Json;
    
    public class StartUp
    {
        static void Main(string[] args)
        {
            // System.Text.Json
            Employee employe = new Employee("Gosho", 30, "C# Developer");

            string jsonFormat = System.Text.Json.JsonSerializer.Serialize(employe, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            File.WriteAllText(@"..\..\..\JSON\output.json", jsonFormat);

            Employee classFormat =
                System.Text.Json.JsonSerializer.Deserialize<Employee>(File.ReadAllText(@"..\..\..\JSON\output.json"));
            Console.WriteLine(classFormat.Name + " - " + classFormat.Age);

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(classFormat, new JsonSerializerOptions
            {
                WriteIndented = true
            }));

            Console.WriteLine();

            // JSON.Net
            Console.WriteLine(JsonConvert.SerializeObject(employe, Formatting.Indented));
            Employee classFormat2 = JsonConvert.DeserializeObject<Employee>(jsonFormat);
            Console.WriteLine(classFormat2.Name + " - " + classFormat2.Age);


            Employee employe2 = new Employee("Pesho", 20, "JS Developer");
            Department it = new Department("IT");
            it.Add(employe);
            it.Add(employe2);


            string departmentJsonFormat = 
                System.Text.Json.JsonSerializer.Serialize(it, new JsonSerializerOptions()
                {
                    WriteIndented = true
                });
            File.WriteAllText(@"..\..\..\JSON\department.json", departmentJsonFormat);

        }
    }
}