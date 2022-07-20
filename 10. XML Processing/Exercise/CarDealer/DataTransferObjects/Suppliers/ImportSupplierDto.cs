using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Suppliers
{
    [XmlType("Suppliers")]
    public class ImportSupplierDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public string IsImporter { get; set; }
    }
}
