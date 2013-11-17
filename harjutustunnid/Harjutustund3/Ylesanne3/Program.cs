using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ylesanne3.OISTeenus;

namespace Ylesanne3
{
    class Program
    {
        static void Main(string[] args)
        {
            TeenusSoapClient client = new TeenusSoapClient();
            var result = client.GetTunniplaan("nimi", "18282");

            foreach (var tund in result)
            {
                Console.WriteLine("{0} {1} {2}", tund.AineNimi, tund.RuumiNr, tund.ÕppejõuNimi);
            }

            Console.ReadKey();
        }
    }
}
