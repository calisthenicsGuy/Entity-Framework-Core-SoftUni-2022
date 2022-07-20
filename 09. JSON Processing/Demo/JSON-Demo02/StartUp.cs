
namespace JSON_Demo02
{
    using JSON_Demo01;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Linq;
    using System.Xml;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Employee employee1 =
                JsonConvert.DeserializeObject<Employee>
                (File.ReadAllText(@"..\..\..\..\JSON-Demo01\JSON\output.json"));

            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "dd-MM-yyyy",
            };
            string json = JsonConvert.SerializeObject(employee1, jsonSettings);
            System.Console.WriteLine(json);


            // LINO to JSON
            JObject jObject = JObject.Parse(json);

            System.Console.WriteLine(jObject["EmployeeName"]);

            foreach (var item in jObject.Children())
            {
                foreach (var item2 in item.Children())
                {
                    System.Console.WriteLine(item2);
                }
            }

            foreach (var keyValuePair in jObject)
            {
                if (keyValuePair.Value.ToString().Contains("G"))
                {
                    System.Console.WriteLine(keyValuePair);
                }
            }

            System.Console.WriteLine();

            // XML to JSON
            string xml = @"<?xml version='1.0' standalone='no'?>
                            <root>
                                <person id='1'>
                                    <name>Alan</name>
                                    <url>www.google.com</url>
                                </person>
                                <person id='2'>
                                    <name>Louis</name>
                                    <url>www.yahoo.com</url>
                                </person>
                            </root>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            System.Console.WriteLine(jsonText);
        }
    }
}
