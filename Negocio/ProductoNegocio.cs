using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Select a.Estado, a.Id, a.Codigo, a.Nombre, a.Precio, a.ImagenUrl , a.Descripcion ,c.Descripcion as Categoria, m.Descripcion as Marca, m.Id as idMarca, c.Id as idCategoria from Articulos a, CATEGORIAS c, MARCAS m where c.Id=a.IdCategoria and m.Id= a.IdMarca and estado = 1");
                datos.ejecutarLectura();

                while (datos.leyo.Read())
                {
                    Producto obj = new Producto();
                    obj.Estado = (bool)datos.leyo["Estado"];
                    obj.Id = (int)datos.leyo["Id"];
                    obj.Codigo = (string)datos.leyo["codigo"];
                    obj.Nombre = (string)datos.leyo["nombre"];
                    obj.Precio = (decimal)datos.leyo["precio"];
                    obj.Precio=decimal.Round(obj.Precio, 2);    //redondeo a 2 dígitos
                    if (!(datos.leyo["ImagenUrl"] is DBNull))
                    {
                        obj.ImagenUrl = (string)datos.leyo["ImagenUrl"];
                    }
                    obj.Descripcion = (string)datos.leyo["Descripcion"];
                    obj.marca = new Marca();
                    obj.marca.Descripcion = (string)datos.leyo["Marca"];
                    obj.categoria_ = new Categoria();
                    obj.categoria_.Descripcion = (string)datos.leyo["Categoria"];
                    obj.marca.Id = (int)datos.leyo["idMarca"];
                    obj.categoria_.Id = (int)datos.leyo["idCategoria"];

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
        public void agregarProducto(Producto nuevoProducto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("insert into ARTICULOS (estado, codigo, nombre, precio, imagenUrl, descripcion, idCategoria, idMarca) values (@estado, @codigo, @nombre, @precio, @imagenUrl, @descripcion, @idCateg, @idMarca)");
                datos.setearParametro("@estado", nuevoProducto.Estado);
                datos.setearParametro("@codigo", nuevoProducto.Codigo);
                datos.setearParametro("@nombre", nuevoProducto.Nombre);
                datos.setearParametro("@precio", nuevoProducto.Precio);
                datos.setearParametro("@imagenUrl", nuevoProducto.ImagenUrl);
                datos.setearParametro("@descripcion", nuevoProducto.Descripcion);
                datos.setearParametro("@idCateg", nuevoProducto.categoria_.Id);
                datos.setearParametro("@idMarca", nuevoProducto.marca.Id);
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
        public void modificarProducto(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Update ARTICULOS set @estado=estado, codigo=@codigo, Nombre=@nombre, precio=@precio, ImagenUrl=@imagenUrl, Descripcion=@descripcion, IdCategoria=@idCategoria, IdMarca=@idMarca where id=@id");
                datos.setearParametro("@estado", producto.Estado);
                datos.setearParametro("@codigo", producto.Codigo);
                datos.setearParametro("@nombre", producto.Nombre);
                datos.setearParametro("@precio", producto.Precio);
                datos.setearParametro("@imagenUrl", producto.ImagenUrl);
                datos.setearParametro("@descripcion", producto.Descripcion);
                datos.setearParametro("@idCategoria", producto.categoria_.Id);
                datos.setearParametro("@idMarca", producto.marca.Id);
                datos.setearParametro("@id", producto.Id);

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
        public void eliminarProducto(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearQuery("delete from ARTICULOS where id= @id");
                datos.setearParametro("@id",id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void eliminarlogico (int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearQuery("update ARTICULOS set estado = 0 where id=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
