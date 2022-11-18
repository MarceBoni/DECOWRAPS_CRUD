using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DECOWRAPS_CRUD.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Catalogos = new HashSet<Catalogo>();
        }

        public int CodProducto { get; set; }
        public string DesProducto { get; set; }
        public decimal Precio { get; set; }
        
        [Range(1, double.MaxValue, ErrorMessage = "Debe Seleccionar un {0}")]
        [Display(Name = "Proveedor", Prompt = "[Seleccione...]")]

        public int IdProveedor { get; set; }
        public int Activo { get; set; }
        public string Referencia { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; }
        public virtual ICollection<Catalogo> Catalogos { get; set; }
    }
}
