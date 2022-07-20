using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XML_Demo01
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // XDocument
            string foodMenuFromXMLFile = File.ReadAllText(@"..\..\..\XMLData\FoodMenu.xml"); // read the text as string
            XDocument document1 = XDocument.Parse(foodMenuFromXMLFile); // parse the particular string to xml document
            XDocument document2 = XDocument.Load(@"..\..\..\XMLData\FoodMenu.xml"); // parse the text to xml file from file path


            // Declaration -> Xml file declaration
            string versionOfXmlFile = document1.Declaration.Version;
            string encodingOfXmlFile = document1.Declaration.Encoding;

            // Root - Linq to XML
            int countOfRootElements = document1.Root.Elements().Count();
            XElement firstElementThatHaveAttributeTest = document1.Root
                .Elements()
                .Where(x => x.Attributes().Any(a => a.Name == "test")).FirstOrDefault();

            XElement firstElementThatHaveElementName = document1.Root.Elements()
                .Where(e => e.Elements().Any(se => se.Name == "name"))
                .FirstOrDefault();

            int totalElementsInDocumnet = document1.Root.Elements().Elements().Count();

            StringBuilder foodsName = new StringBuilder();
            foreach (var food in document1.Root.Elements())
            {
                foodsName.AppendLine(food.Element("name").Value);
            }

            // Change the XML document ->
            // SetElementValue, Remove, RemoveAll, Attribute, SetAttributeValue, RemoveAttributes
            /* foreach (var food in document1.Root.Elements())
            {
                food.SetAttributeValue("food", food.Element("name").Value.ToString());
            }
            document1.Save(@"..\..\..\XMLData\FoodMenu_02.xml"); */

            List<XElement> foodsThatHaveMoreThan800Calories = document1.Root.Elements()
                .Where(x => int.Parse((string)x.Element("calories")) > 800)
                .ToList();


        }
    }
}