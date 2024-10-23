using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Security.AccessControl;
using System.Net;
using System.Globalization;

namespace Negocio
{
    public class DiscosNegocio
    {
        public List<Disco> listar()
        {
            //Creo el objeto List para los elementos y datos para la conexion
            List<Disco> lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearConsulta("Select D.Id, Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E. Descripcion as 'Estilo',T. Descripcion as 'Tipo de edicion', D.IdEstilo, D.IdTipoEdicion\r\nfrom DISCOS D, ESTILOS E, TIPOSEDICION T\r\nwhere D.IdEstilo = E.Id and D.IdTipoEdicion = T.Id And D.Activo = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)datos.Lector["CantidadCanciones"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("UrlImagenTapa"))))
                        aux.UrlImagen = (string)datos.Lector["UrlImagenTapa"];
                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)datos.Lector["Estilo"];
                    aux.TipoEdicion = new TipoEdicion();
                    aux.TipoEdicion.Id = (int)datos.Lector["IdTipoEdicion"];
                    aux.TipoEdicion.Descripcion = (string)datos.Lector["Tipo de edicion"];

                    lista.Add(aux);
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

        public void agregarDisco(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into DISCOS(Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion, Activo)values('" + nuevo.Titulo + "','" + nuevo.FechaLanzamiento + "'," + nuevo.CantidadCanciones + ",'" + nuevo.UrlImagen + "', @idEstilo, @idTipoEdicion, @Activo)");
                datos.setearParametros("@idEstilo", nuevo.Estilo.Id);
                datos.setearParametros("@idTipoEdicion", nuevo.TipoEdicion.Id);
                datos.setearParametros("@Activo", 1);
                datos.ejecutarAccion();
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

        public void modificarDisco(Disco seleccionado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE DISCOS set Titulo = @Titulo, FechaLanzamiento = @Fecha, CantidadCanciones = @CantCanciones, UrlImagenTapa = @Img, IdEstilo = @IdEstilo, IdTipoEdicion = @IdTipoEdicion\r\nwhere Id = @Id");

                datos.setearParametros("@Titulo", seleccionado.Titulo);
                datos.setearParametros("@Fecha", seleccionado.FechaLanzamiento);
                datos.setearParametros("@CantCanciones", seleccionado.CantidadCanciones);
                datos.setearParametros("@Img", seleccionado.UrlImagen);
                datos.setearParametros("@IdEstilo", seleccionado.Estilo.Id);
                datos.setearParametros("@IdTipoEdicion", seleccionado.TipoEdicion.Id);
                datos.setearParametros("@Id", seleccionado.Id);

                datos.ejecutarAccion();
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

        public void eliminarFisico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE from DISCOS where id = @Id");
                datos.setearParametros("@Id", id);
                datos.ejecutarAccion();
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

        public void eliminarLogico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update DISCOS set Activo = 0 where Id = @Id");
                datos.setearParametros("@Id", id);
                datos.ejecutarAccion();
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

        public List<Disco> filtrar(string campo, string criterio, string filtro)
        {
            List<Disco> lista = new List<Disco> ();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select D.Id, Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E. Descripcion as 'Estilo',T. Descripcion as 'Tipo de edicion', D.IdEstilo, D.IdTipoEdicion from DISCOS D, ESTILOS E, TIPOSEDICION T where D.IdEstilo = E.Id and D.IdTipoEdicion = T.Id And D.Activo = 1 And ";
                if (campo == "Cantidad de canciones")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "CantidadCanciones > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "CantidadCanciones < " + filtro;
                            break;
                        default:
                            consulta += "CantidadCanciones = " + filtro;
                            break;
                    }
                }
                else if (campo == "Titulo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Titulo like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Titulo like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Titulo like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "E. Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "E. Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "E. Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearConsulta( consulta );
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)datos.Lector["CantidadCanciones"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("UrlImagenTapa"))))
                        aux.UrlImagen = (string)datos.Lector["UrlImagenTapa"];
                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)datos.Lector["Estilo"];
                    aux.TipoEdicion = new TipoEdicion();
                    aux.TipoEdicion.Id = (int)datos.Lector["IdTipoEdicion"];
                    aux.TipoEdicion.Descripcion = (string)datos.Lector["Tipo de edicion"];

                    lista.Add(aux);
                }

            return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
