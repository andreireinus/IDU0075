using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ylesanne1
{
    class Program
    {
        static void Main(string[] args)
        {
            OIS ois = new OIS();

            var result = ois.GetTunniplaan("Andrei Reinus", "iabb11881");
        }
    }
}