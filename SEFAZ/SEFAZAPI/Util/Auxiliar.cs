using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEFAZAPI.Util
{
    public class Auxiliar
    {
        public string GerarUrlMaps(string numlatitude, string numlongitude)
        {
            return "https://www.google.com/maps/search/?api=1&query=" + numlatitude + "," + numlongitude;
        }
    }
}
