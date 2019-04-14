using System.Collections.Generic;
using Entidades;

namespace Repositorio.Interfaces
{
    public interface IRepositorioProcesoGenerico
    {
        string ConsultarRegistro(string campos, string valoresFiltro, string conexion);
        void GuardarRegistro(string campos, string valores, bool esNuevo, string conexion);
        void EliminarRegistro(string valores, string conexion);
    }
}
