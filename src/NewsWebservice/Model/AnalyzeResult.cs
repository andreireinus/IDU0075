using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsWebservice.Model
{
    public class AnalyzeResult
    {
        public string StockTicker { get; set; }
        public string NewsUrl { get; set; }
        public DateTime NewsDate { get; set; }
        public double OpenPrice { get; set; }
        public double ClosePrice { get; set; }
        public double Change
        {
            get
            {
                return (1 - (OpenPrice / ClosePrice)) * 100;
            }
        }
    }
}