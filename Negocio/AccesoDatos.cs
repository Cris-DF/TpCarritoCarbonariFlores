using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Negocio
{
    class AccesoDatos
    {        //GETTERS Y SETTERS / ATRIBUTOS
        public SqlConnection conexion { get; set; }
        public SqlCommand comando { get; set; }
        public SqlDataReader leyo { get; set; }

        //CONSTRUCTOR
        public AccesoDatos()
        {
            conexion = new SqlConnection("server = .\\SQLEXPRESS; database = CATALOGO_DB; integrated security = true");
            //conexion = new SqlConnection("server = .\\VERONICA; database = CATALOGO_DB; integrated security = true");
            comando = new SqlCommand();
        }

        //METODOS
        public SqlDataReader Leyo
        {
            get { return leyo; }

        }

        public void setearQuery(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                leyo = comando.ExecuteReader();

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

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (leyo != null)
            {
                leyo.Close();
            }
            conexion.Close();
        }

    }
}
