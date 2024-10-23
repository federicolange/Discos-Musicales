using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EstiloNegocio
    {
        public List<Estilo> listar()
        {
            List<Estilo> lista = new List<Estilo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion\r\nFrom Estilos\r\n");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Estilo estilo = new Estilo();
                    estilo.Id = (int)datos.Lector["Id"];
                    estilo.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(estilo);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
