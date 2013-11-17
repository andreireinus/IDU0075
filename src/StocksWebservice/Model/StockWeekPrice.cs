using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StocksWebservice.Model
{
    public class StockWeekPrice
    {
        [XmlIgnore]
        public Stock Stock { get; set; }

        public int Year { get; set; }
        public int Week { get; set; }

        public double StartPrice { get; set; }
        public double EndPrice { get; set; }

        public double Change
        {
            get
            {
                return (1 - EndPrice / StartPrice) * 100;
            }
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1}/{2} - {3:0.000}", Stock.TickerCode, Year, Week, Change);
        }
    }
}
