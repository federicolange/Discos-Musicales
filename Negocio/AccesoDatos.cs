using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        //declaro atributos a usar en la conexion
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        //propiedad solo lectura del lector
        public SqlDataReader Lector
        { 
            get { return lector; } 
        }

        //constructor
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; Database=DISCOS_DB; integrated security= true");
            comando = new SqlCommand();
        }

        //metodo para setear una consulta
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //metodo para ejecutar una lectura
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //metodo para setear parametros en la consulta
        public void setearParametros(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        //metodo para cerrar la conexion y el lector
        public void cerrarConexion()
        {
            if(lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }
    }
}
