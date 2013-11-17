using NewsWebservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NewsWebservice
{
    [WebService(Namespace = "http://idu0075.ttu.ee/111881/News/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class NewsService : System.Web.Services.WebService
    {
        [WebMethod]
        public AnalyzeResult[] Analyze(string url, DateTime time)
        {
            AnalyzeResult[] result;

            if (!Database.Exists(url))
            {
                Analyze analyze = new Analyze(url, time);
                result = analyze.GetResult();
            }
            else
            {
                result = Database.Fetch(url);
            }

            return result;
        }
    }
}
