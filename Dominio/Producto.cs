using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


/*Se agregan display name para mejorar visual en form
 * 
 * 
 */

namespace Dominio
{
    public class Producto
    {
        public int Id { get; set; }

        //Anotations sirve para cambiar el nombre a distintas cosas
        //la anotation va antes de la variable a modificar formato
        [DisplayName("Código")] 
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Marca")]
        public Marca marca { get; set; }
        [DisplayName("Categoría")]
        public Categoria categoria_ { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
    }
}
