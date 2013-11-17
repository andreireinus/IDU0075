using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Ylesanne2
{
    [WebService(Namespace = "http://idu0075.ttu.ee/iabb111881/ois/teenus")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Teenus : System.Web.Services.WebService
    {

        [WebMethod]
        public Tund[] GetTunniplaan(string nimi, string matrikliNr)
        {
            var ois = new OIS();
            return ois.GetTunniplaan(nimi, matrikliNr);
        }
    }
}
