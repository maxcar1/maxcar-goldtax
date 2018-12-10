using System.Xml.Serialization;

namespace maxcar_goldtax.entity
{
    [XmlType("FPXT_COM_INPUT")]
    public class RequestInfo {
        [XmlElement("ID")]
        public string Id { get; set; }

        [XmlElement("DATA")]
        public string Data { get; set; }
    }
}
