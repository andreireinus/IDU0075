using System;
using System.Xml.Serialization;

namespace StocksWebservice.Model
{
    public class StockPrice
    {
        [XmlIgnore]
        public Stock Stock { get; set; }
        public DateTime Date { get; set; }

        public double OpenPrice { get; set; }
        public double HighPrice { get; set; }
        public double LowPrice { get; set; }
        public double ClosePrice { get; set; }
    }
}
