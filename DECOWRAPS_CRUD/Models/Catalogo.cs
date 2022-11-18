using System;
using System.Collections.Generic;

#nullable disable

namespace DECOWRAPS_CRUD.Models
{
    public partial class Catalogo
    {
        public int Id { get; set; }
        public int CodCatalogo { get; set; }
        public int CodProducto { get; set; }
        public string DesProducto { get; set; }
        public decimal Precio { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual CatalogoCliente CodCatalogoNavigation { get; set; }
        public virtual Producto CodProductoNavigation { get; set; }
    }
}
