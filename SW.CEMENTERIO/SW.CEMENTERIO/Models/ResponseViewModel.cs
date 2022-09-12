using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.CEMENTERIO.Models
{
    public class ResponseViewModel
    {
        public bool Estado { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public IEnumerable<dynamic> Datos { get; set; }
        public int Tipo { get; set; }   //-1 sesion expirada //0 : éxito sin datos //1: Éxito con datos  //2: error
        public int AdicionalInt { get; set; }
        public int AdicionalTxt { get; set; }
    }
}
