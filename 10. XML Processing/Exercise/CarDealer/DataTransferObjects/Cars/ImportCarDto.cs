using CarDealer.Models;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace CarDealer.DataTransferObjects.Cars
{
    [XmlType("Car")]
    public class ImportCarDto
    {
        [XmlElement("make")]
        public string Make { get; set; }
        public string Model { get; set; }
        public long TraveledDistance { get; set; }
        public ICollection<Part> Parts { get; set; }
    }
}
