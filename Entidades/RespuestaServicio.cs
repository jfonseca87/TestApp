using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RespuestaServicio
    {
        public int HttpRespuesta { get; set; }
        public object RespuestaExitosa { get; set; }
        public string RespuestaError { get; set; }
    }
}
