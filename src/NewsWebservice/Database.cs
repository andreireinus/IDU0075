using NewsWebservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsWebservice
{
    internal class Database
    {
        private static Database _instance;
        static Database()
        {
            _instance = new Database();
        }

        public static IQueryable<AnalyzeResult> Results { get { return _instance._Results.AsQueryable(); } }

        private Database()
        {
            _Results = new List<AnalyzeResult>();
        }

        private List<AnalyzeResult> _Results { get; set; }

        internal static void AddResult(AnalyzeResult result)
        {
            _instance._Results.Add(result);
        }

        internal static AnalyzeResult[] Fetch(string url)
        {
            return _instance._Results.Where(a => a.NewsUrl == url).ToArray();
        }

        internal static bool Exists(string url)
        {
            return _instance._Results.Where(a => a.NewsUrl == url).Any();
        }
    }
}