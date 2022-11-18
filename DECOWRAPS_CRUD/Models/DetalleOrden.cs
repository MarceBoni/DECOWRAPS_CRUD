using System;
using System.Collections.Generic;

#nullable disable

namespace DECOWRAPS_CRUD.Models
{
    public partial class DetalleOrden
    {
        public int IdDetalleorden { get; set; }
        public int IdOrden { get; set; }
        public int CodProducto { get; set; }
        public string DesProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        public virtual OrdenDecowrap IdOrdenNavigation { get; set; }
    }
}
