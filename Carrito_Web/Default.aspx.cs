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
    public partial class Default : System.Web.UI.Page
    {        
        List<Producto> listProductos;
        DatosSession datos;

        protected void Page_Load(object sender, EventArgs e)
        {
            datos = new DatosSession(Session);
            ProductoNegocio prodNeg = new ProductoNegocio();
            listProductos = prodNeg.listar();

            if (!IsPostBack)
            {
                cargarFiltros();
                cargarParametros();
                filtrar();
                repProductos.DataBind();
            }


        }

        /// <summary>
        /// se cargan los parametros de filtros cargados en la URL(si existen)
        /// </summary>
        private void cargarParametros()
        {
            if (Request.QueryString["Marca"] != null)
            {
                lbMarca.SelectedValue = Request.QueryString["Marca"].ToString();
            }
            if(Request.QueryString["Cat"] != null)
            {
                lbCategoria.SelectedValue = Request.QueryString["Cat"].ToString();   
            }
            if(Request.QueryString["Busqueda"] != null)
            {
                txtABuscar.Text = Request.QueryString["Busqueda"].ToString();
            }
        }

        /// <summary>
        /// la funcion filtrar genera la nueva lista a partir de los parametros de busqueda cargados
        /// </summary>
        public void filtrar()
        {
            List<Producto> listaFiltrada= listProductos;

            if (lbMarca.SelectedValue != "")
            {

                listaFiltrada = listaFiltrada.FindAll(x => x.marca.Descripcion.ToUpper() == lbMarca.SelectedValue.ToUpper());
            }
            if (lbCategoria.SelectedValue != "")
            {

                listaFiltrada = listaFiltrada.FindAll(x => x.categoria_.Descripcion.ToUpper() == lbCategoria.SelectedValue.ToUpper());
            }
            if (txtABuscar.Text.Length >= 2)
            {

                listaFiltrada = listaFiltrada.FindAll(x => x.Nombre.ToUpper().Contains(txtABuscar.Text.ToUpper()));
            }

            repProductos.DataSource = listaFiltrada;
            
        }

        public Producto buscarProd(int id)
        {
            Producto producto = new Producto();

            producto = listProductos.Find(x => x.Id == id);

            return producto;
        }

        protected void BtnCard_Click(object sender, EventArgs e)
        {
            int idProd = int.Parse(((Button)sender).CommandArgument);
            Producto nuevoProd = buscarProd(idProd);
            ItemsComprados nuevo = new ItemsComprados();
            int pos = -1;

            nuevo.Id = nuevoProd.Id;
            nuevo.Nombre = nuevoProd.Nombre;
            nuevo.Descripcion = nuevoProd.Descripcion;
            nuevo.Cantidad = 1;
            nuevo.Precio = nuevoProd.Precio;
            nuevo.PrecioUni = nuevoProd.Precio;
            nuevo.ImagenUrl = nuevoProd.ImagenUrl;

            List<ItemsComprados> listSesion = datos.listaSession();
            ItemsComprados seleccionado = listSesion.Find(x => x.Id == idProd);

            if (seleccionado != null)
            {
                pos = datos.buscarPosId(seleccionado.Id);
                if (pos != -1)
                {
                    listSesion[pos].Cantidad++;
                    listSesion[pos].Precio = nuevo.Precio * listSesion[pos].Cantidad;
                }
            }
            else
            {
                listSesion.Add(nuevo);
            }
            Session.Add("listaItemsCarrito", listSesion);

            Response.Redirect("Default.aspx?Marca=" + lbMarca.SelectedValue.ToString() + "&Cat=" + lbCategoria.SelectedValue.ToString() + "&Busqueda=" + txtABuscar.Text + "", false);
        }

       


        /// <summary>
        /// Esta funcion carga los datos correspondientes en los desplegables de Categorias y Marcas
        /// </summary>
        private void cargarFiltros()
        {
            Categoria catVacia = new Categoria();
            catVacia.Descripcion = ""; catVacia.Id = -1;
            Marca marcaVacia = new Marca();
            marcaVacia.Descripcion = ""; marcaVacia.Id = -1;
            CategoriaNegocio catNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            //A las listas a mostrar se les inserta un primer elemento vacio para poder limpiar el filtro desde el mismo desplegable
            List<Marca> marcas = marcaNegocio.listar(); marcas.Insert(0, marcaVacia);
            List<Categoria> categorias = catNegocio.listar(); categorias.Insert(0, catVacia);

            lbMarca.DataSource = marcas;
            lbMarca.DataBind();
            lbCategoria.DataSource = categorias;
            lbCategoria.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            redireccionarUrl();
        }

        protected void lbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            redireccionarUrl();
        }

        protected void lbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            redireccionarUrl();
        }


        /// <summary>
        /// //al presionar el boton buscar se redirecciona a la misma pagina mandando los parametros de filtros y busqueda
        /// </summary>
        private void redireccionarUrl()
        {

            Response.Redirect("Default.aspx?Marca=" + lbMarca.SelectedValue.ToString() + "&Cat=" + lbCategoria.SelectedValue.ToString() + "&Busqueda=" + txtABuscar.Text + "", false);
        }
    }
}