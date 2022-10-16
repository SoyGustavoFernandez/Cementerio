using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.CEMENTERIO.ENT
{
    public class TotalDifuntos
    {
        public int CANTIDAD_DIFUNTOS { get; set; }
        public string PABELLON { get; set; }
    }

    public class TotalPabellon
    {
        public int NICHOS_LIBRES { get; set; }
        public int NICHOS_OCUPADOS { get; set; }
        public string PABELLON { get; set; }
    }

}
