using System.Xml.Serialization;

namespace maxcar_goldtax.entity
{
    [XmlType("FPXT_COM_OUTPUT")]

    public class ResponseInfo {
        [XmlElement("ID")]
        public string Id { get; set; }

        [XmlElement("CODE")]
        public string Code { get; set; }

        [XmlElement("MESS")]

        public string Message { get; set; }

        [XmlElement("DATA")]
        public string Data { get; set; }
    }
}
