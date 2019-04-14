using System.Collections.Generic;
using Entidades;
using NegocioServicio.Interfaces;
using Repositorio.Interfaces;

namespace NegocioServicio.Clases
{
    public class NegocioProcesoGenerico : INegocioProcesoGenerico
    {
        private readonly IRepositorioProcesoGenerico repoProcesoGenerico;

        public NegocioProcesoGenerico(IRepositorioProcesoGenerico repoProcesoGenerico)
        {
            this.repoProcesoGenerico = repoProcesoGenerico;
        }

        public IEnumerable<Valor> ConsultarRegistro(string campos, string valoresFiltro, string conexion)
        {
            string respuesta = string.Empty;
            respuesta = this.repoProcesoGenerico.ConsultarRegistro(campos, valoresFiltro, conexion);

            return new List<Valor>();
        }

        public void EliminarRegistro(string valores, string conexion)
        {
            this.repoProcesoGenerico.EliminarRegistro(valores, conexion);
        }

        public void GuardarRegistro(string campos, string valores, bool esNuevo, string conexion)
        {
            this.repoProcesoGenerico.GuardarRegistro(campos, valores, esNuevo, conexion);
        }
    }
}
