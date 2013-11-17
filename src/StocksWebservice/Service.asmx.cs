using StocksWebservice.Model;
using System;
using System.Linq;
using System.Web.Services;
using Utils;

namespace StocksWebservice
{
    [WebService(Namespace = "http://idu0075.ttu.ee/111881/Stocks/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Service : System.Web.Services.WebService
    {
        [WebMethod]
        public string[] GetTickers()
        {
            return Database.Stocks.Select(s => s.TickerCode).ToArray().OrderBy(s => s).ToArray();
        }

        [WebMethod]
        public StockPrice[] GetPrices(string ticker, DateTime from, DateTime to)
        {
            return Database.StockPrices
                .Where(p => p.Stock.TickerCode == ticker)
                .Where(p => p.Date >= from)
                .Where(p => p.Date <= to)
                .OrderBy(p => p.Date)
                .ToArray();
        }

        [WebMethod]
        public StockWeekPrice GetWeeklyPrice(string stock, DateTime date)
        {
            int week = date.GetWeekOfYear();
            int year = date.Year;

            var query = from p in Database.StockPrices
                        where
                            p.Date.Year == year
                            && p.Date.GetWeekOfYear() == week
                            && p.Stock.TickerCode == stock
                        select p;

            if (!query.Any())
            {
                return null;
            }

            var price = new StockWeekPrice
            {
                Year = year,
                Week = week,
                Stock = query.First().Stock,
                StartPrice = query.OrderBy(p => p.Date).First().OpenPrice,
                EndPrice = query.OrderByDescending(p => p.Date).First().ClosePrice,
            };

            return price;
        }
    }
}
