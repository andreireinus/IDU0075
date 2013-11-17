using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ylesanne1
{
    public class OIS
    {
        public Tund[] GetTunniplaan(string nimi, string martrikliNr)
        {
            List<Tund> tunnid = new List<Tund>();
            tunnid.Add(new Tund { AineNimi = "IDU0075", RuumiNr = "X-123", ÕppejõuNimi = "Tarvo Teier" });
            tunnid.Add(new Tund { AineNimi = "IDU0076", RuumiNr = "V-321", ÕppejõuNimi = "Kati Karu" });
            tunnid.Add(new Tund { AineNimi = "IDU0073", RuumiNr = "III-222", ÕppejõuNimi = "Mati Murakas" });

            return tunnid.ToArray();
        }
    }
}
