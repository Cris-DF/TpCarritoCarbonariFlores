using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Carrito_Web.clases
{
    public class DatosSession
    {
        public int cantidadIconoCarrito { get; set; }

        private HttpSessionState session;

        public DatosSession(HttpSessionState sess)
        {
            session = sess;
        }

        public List<ItemsComprados> listaSession()
        {
            List<ItemsComprados> productosEnCarrito = session["listaItemsCarrito"] != null ?
                (List<ItemsComprados>)session["listaItemsCarrito"] : new List<ItemsComprados>();

            return productosEnCarrito;
        }


        public void ModificarCarrito(List<ItemsComprados> listaNueva)
        {
            session.Add("listaItemsCarrito", listaNueva);
        }

        public int buscarPosId(int id)
        {
            int pos = -1;

            List<ItemsComprados> listSesion = listaSession();

            foreach (var item in listSesion)
            {
                if (item.Id == id)
                {
                    pos = listSesion.IndexOf(item);

                    return pos;
                }
            }
            return -1;
        }
        public string buscarNombre(int id)
        {
            List<ItemsComprados> listSesion = listaSession();
            string nombre = null;

            foreach (var item in listSesion)
            {
                if (item.Id == id)
                {
                    return item.Nombre;
                }
            }
            return nombre;
        }
        public ItemsComprados buscarObjeto(int id)
        {
            List<ItemsComprados> listSesion = listaSession();

            foreach (var item in listSesion)
            {
                if (item.Id == id)
                {

                    return item;
                }
            }
            return null;
        }

    }

}
