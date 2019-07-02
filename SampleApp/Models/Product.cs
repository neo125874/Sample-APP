using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleApp.Models
{
    [XmlRoot(ElementName = "product")]
    public class Product
    {
        [XmlElement(ElementName = "SN")]
        public string SN { get; set; }
        [XmlElement(ElementName = "PN")]
        public string PN { get; set; }
        [XmlElement(ElementName = "IO")]
        public string IO { get; set; }
        [XmlElement(ElementName = "FW")]
        public string FW { get; set; }
    }
}
