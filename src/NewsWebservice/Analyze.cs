using HtmlAgilityPack;
using NewsWebservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace NewsWebservice
{
    public class Analyze
    {
        private List<string> _searchStocks = new List<string>();
        private List<string> _existingStock = new List<string>();

        private string url;
        private DateTime time;
        public Analyze(string url, DateTime time)
        {
            this.url = url;
            this.time = time;
        }

        public AnalyzeResult[] GetResult()
        {
            Service stockClient = new Service();
            _searchStocks.AddRange(stockClient.GetTickers());

            WebClient client = new WebClient();
            string source = client.DownloadString(url);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(source);

            AnalyzeNode(document.DocumentNode);
            foreach (var stock in _existingStock)
            {
                var price = stockClient.GetWeeklyPrice(stock, time);

                if (price == null)
                {
                    continue;
                }

                var result = new AnalyzeResult
                {
                    StockTicker = stock,
                    NewsDate = time,
                    NewsUrl = url,
                    OpenPrice = price.StartPrice,
                    ClosePrice = price.EndPrice
                };

                Database.AddResult(result);
            }

            return Database.Fetch(url);
        }

        private void AnalyzeNode(HtmlNode node)
        {
            if (node == null)
            {
                return;
            }

            string text = string.Empty;
            if (node.NodeType == HtmlNodeType.Text)
            {
                text = node.InnerText;
            }


            List<string> added = new List<string>();
            foreach (var stock in _searchStocks)
            {
                if (text.Contains(stock))
                {
                    _existingStock.Add(stock);
                    added.Add(stock);
                }
            }
            foreach (var stock in added)
            {
                _searchStocks.Remove(stock);
            }

            foreach (var child in node.ChildNodes)
            {
                AnalyzeNode(child);
            }
        }
    }
}