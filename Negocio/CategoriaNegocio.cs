using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

/*Creo método listar
 */

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Select id, Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.leyo.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)datos.leyo["id"];
                    aux.Descripcion = (string)datos.leyo["descripcion"];

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
        public void agregarCategoria(Categoria nuevaCateg)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("insert into CATEGORIAS (idMarca, descripcion) values (@id, @descripcion))");
                datos.setearParametro("@idMarca", nuevaCateg.Id);
                datos.setearParametro("@descripcion", nuevaCateg.Descripcion);
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
        public void modificarCategoria(Categoria categ)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Update categorias set descripcion=@descripcion where Id=@id");
                datos.setearParametro("@id", categ.Id);
                datos.setearParametro("@descripcion", categ.Descripcion);

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
