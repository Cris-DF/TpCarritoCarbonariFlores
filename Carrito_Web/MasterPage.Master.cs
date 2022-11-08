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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        List<ItemsComprados> listProd;
        DatosSession datos;
   
        ItemsComprados obj = new ItemsComprados();

        protected void Page_Load(object sender, EventArgs e)
        {
            datos = new DatosSession(Session);
            listProd = datos.listaSession();

            lblCantCart.Text = totalArticulos().ToString();
        }

        public int totalArticulos()
        {
            int acumulador = 0;
            foreach (var cadaProducto in listProd)
            {
                acumulador += cadaProducto.Cantidad;
            }
            return acumulador;
        }

    }
}