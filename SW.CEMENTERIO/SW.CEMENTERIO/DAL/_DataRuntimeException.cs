using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.ApplicationBlocks.Data
{
    /// <summary>
    /// Excepcion que se produce en la capa de datos
    /// </summary>
    public class _DataRuntimeException:ApplicationException
    {
        public _DataRuntimeException(string mensaje) : base(mensaje) { }
        public _DataRuntimeException(string mensaje,Exception inner) : base(mensaje,inner) { }
    }
}
