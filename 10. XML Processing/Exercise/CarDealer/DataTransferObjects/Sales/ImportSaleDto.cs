using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Sales
{
    [XmlType("sale")]
    public class ImportSaleDto
    {
        [XmlElement("")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int customerId { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }
    }
}
