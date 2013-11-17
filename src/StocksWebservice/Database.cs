using StocksWebservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace StocksWebservice
{
    internal class Database
    {
        private static Database _instance;
        static Database()
        {
            _instance = new Database();
        }

        public static IQueryable<Stock> Stocks { get { return _instance._Stocks.AsQueryable(); } }
        public static IQueryable<StockPrice> StockPrices { get { return _instance._StockPrices.AsQueryable(); } }

        private Database()
        {
            _Stocks = new List<Stock>();
            _StockPrices = new List<StockPrice>();

            PopulateDataset("AAPL", "Apple", "StocksWebservice.Dataset.apple_data.csv");
            PopulateDataset("GOOG", "Google", "StocksWebservice.Dataset.google_data.csv");
            PopulateDataset("MSFT", "Microsoft", "StocksWebservice.Dataset.microsoft_data.csv");
            PopulateDataset("YHOO", "Yahoo", "StocksWebservice.Dataset.yahoo_data.csv");
        }

        private List<Stock> _Stocks { get; set; }
        private List<StockPrice> _StockPrices { get; set; }

        private object obj = 1;

        private void PopulateDataset(string ticker, string name, string resourceName)
        {
            var stock = new Stock
            {
                TickerCode = ticker,
                Name = name
            };

            var stream = Assembly.GetCallingAssembly().GetManifestResourceStream(resourceName);
            using (var reader = new PriceReader(stream))
            {
                while (reader.Read())
                {
                    var price = reader.GetRecord(stock);

                    lock (obj)
                    {
                        _StockPrices.Add(price);
                    }
                }
            }

            lock (obj)
            {
                _Stocks.Add(stock);
            }
        }
    }

}