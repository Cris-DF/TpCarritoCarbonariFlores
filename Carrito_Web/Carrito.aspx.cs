using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using Carrito_Web.clases;

namespace Carrito_Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DatosSession datos;
        List<ItemsComprados> listProd;
        protected void Page_Load(object sender, EventArgs e)
        {
            datos = new DatosSession(Session);
            listProd = datos.listaSession();

            if (!IsPostBack)
            {
                repCarrito.DataSource = listProd;
                repCarrito.DataBind();
            }
            lblTotalCarrito.Text= "$"+totalAPagar(listProd).ToString();

            if (lblTotalCarrito.Text != "$0")
            {
                lblCarritoVacio.Visible = false;
            }
        }

        private void sumarCantidadProd(int idProd, int cant) 
        {
            ItemsComprados item = new ItemsComprados();

            int index = datos.buscarPosId(idProd);
            item = listProd[index];

            if (cant > 0 || item.Cantidad > 1)
            {
                item.Cantidad += cant;
                item.Precio = item.PrecioUni * item.Cantidad;

                datos.ModificarCarrito(listProd);
            }
            else
            {
            if (cant < 0)
                if (item.Cantidad == 1)
                {
                    {
                        eliminarItem(idProd);
                    }
                }
            }
            repCarrito.DataSource = datos.listaSession();
            repCarrito.DataBind();
            Response.Redirect("Carrito.aspx?", false);

        }
        private void eliminarItem(int idProd)
        {
            int pos = datos.buscarPosId(idProd);
            string nombre = datos.buscarNombre(idProd);
            ItemsComprados proAEliminar = datos.buscarObjeto(idProd);
            Session.Remove(nombre);
            listProd.Remove(proAEliminar);

            repCarrito.DataSource = listProd;
            repCarrito.DataBind();
            Response.Redirect("Default.aspx?", false);
            Response.Redirect("Carrito.aspx?", false);

        }

        private decimal totalAPagar(List<ItemsComprados> listProd)
        {
            decimal acumulado = 0;

            foreach (var cadaItem in listProd)
            {
                acumulado += cadaItem.Precio;
            }
            return acumulado;
        }
        protected void BtnMasCant_Click(object sender, EventArgs e)
        {
            int idProd = int.Parse(((Button)sender).CommandArgument);
            sumarCantidadProd(idProd, 1);
            
        }

        protected void BtnMenosCant_Click(object sender, EventArgs e)
        {
            int idProd = int.Parse(((Button)sender).CommandArgument);
            sumarCantidadProd(idProd, -1);
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            int idProd = int.Parse(((Button)sender).CommandArgument);
            eliminarItem(idProd); 
        }
    }
}