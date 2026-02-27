using System.Collections.Generic;
using System.Xml.Serialization;

namespace StockDatasCollection.Models
{
    [XmlRoot("StockCodes")]
    public class StockCodeList
    {
        [XmlElement("Stock")]
        public List<StockCode> Items { get; set; } = new List<StockCode>();
    }

    public class StockCode
    {
        [XmlElement("Code")]
        public string Code { get; set; }   // e.g. "sh600519"

        [XmlElement("Name")]
        public string Name { get; set; }   // e.g. "贵州茅台" (auto-filled after first fetch)

        [XmlElement("Notes")]
        public string Notes { get; set; }  // optional user note

        public override string ToString() => $"{Code} {Name}";
    }
}
