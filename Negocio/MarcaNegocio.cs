using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Select id, Descripcion from marcas");
                datos.ejecutarLectura();

                while (datos.leyo.Read())
                {
                    Marca obj = new Marca();
                    obj.Id = (int)datos.leyo["id"];
                    obj.Descripcion = (string)datos.leyo["descripcion"];

                    lista.Add(obj);
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
        public void agregarMarca(Marca nuevaMarca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("insert into MARCAS (descripcion) values (@descripcion))");
                datos.setearParametro("@descripcion", nuevaMarca.Descripcion);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificarMarca(Marca mar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Update marcas set descripcion=@descripcion where Id=@id");
                datos.setearParametro("@id", mar.Id);
                datos.setearParametro("@descripcion", mar.Descripcion);

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
    }
}
