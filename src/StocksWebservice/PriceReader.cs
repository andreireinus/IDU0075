using CsvHelper;
using StocksWebservice.Model;
using System;
using System.Globalization;
using System.IO;

namespace StocksWebservice
{
    internal class PriceReader : IDisposable
    {
        CsvReader _reader;
        StreamReader _streamReader;
        internal PriceReader(Stream stream)
        {
            _streamReader = new StreamReader(stream);
            _reader = new CsvReader(_streamReader);
        }

        internal virtual bool Read()
        {
            return _reader.Read();
        }

        internal StockPrice GetRecord(Stock stock)
        {
            StockPrice price = new StockPrice
            {
                Stock = stock
            };

            price.Date = _reader.GetField<DateTime>(0);
            price.OpenPrice = double.Parse(_reader.GetField(1), CultureInfo.InstalledUICulture);
            price.HighPrice = double.Parse(_reader.GetField(2), CultureInfo.InstalledUICulture);
            price.LowPrice = double.Parse(_reader.GetField(3), CultureInfo.InstalledUICulture);
            price.ClosePrice = double.Parse(_reader.GetField(4), CultureInfo.InstalledUICulture);

            return price;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.WaitForFullGCComplete();
        }

        protected virtual void Dispose(bool onlyManaged)
        {
            if (onlyManaged && _reader != null)
            {
                _reader.Dispose();
            }

            if (onlyManaged && _streamReader != null)
            {
                _streamReader.Dispose();
            }
        }
    }
}
