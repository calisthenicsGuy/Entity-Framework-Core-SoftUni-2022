using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CreatingXMLFileWthLINQ
{
    [XmlType("book")]
    public class Book
    {

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlIgnore]
        public string Descroption { get; set; }
    }
    public class StartUp
    {
        static void Main(string[] args)
        {
           /*  XDocument document = new XDocument();
            XElement root = new XElement("Library");
            document.Add(root);

            for (int i = 1; i <= 100; i++)
            {
                XElement book = new XElement("book");
                root.Add(book);
                book.Add(new XElement("title", $" #{i} "));
                book.Add(new XElement("price", $"${i + 2.5}"));
            }

            document.Save(@"..\..\..\XMLData\Library.xml"); */

            // Deserialize - Xml to ojects
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>), new XmlRootAttribute("library"));
            List<Book> books1 = (List<Book>)serializer.Deserialize(File.OpenRead(@"..\..\..\XMLData\Library.xml"));


            // Serialize - Ojects to Xml
            List<Book> books2 = new List<Book>();
            books2.Add(new Book() { Title = "Book1", Price = 20.00m });
            books2.Add(new Book() { Title = "Book2", Price = 18.00m });
            books2.Add(new Book() { Title = "Book3", Price = 22.00m });
            serializer.Serialize(File.OpenWrite(@"..\..\..\XMLData\randomBooks.xml"), books2);

        }
    }
}
