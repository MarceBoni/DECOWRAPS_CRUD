using System;
using System.Collections.Generic;

#nullable disable

namespace DECOWRAPS_CRUD.Models
{
    public partial class OrdenDecowrap
    {
        public OrdenDecowrap()
        {
            Despachos = new HashSet<Despacho>();
            DetalleOrdens = new HashSet<DetalleOrden>();
        }

        public int IdOrden { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int IdVendedor { get; set; }
        public string NombreVendedor { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public string NoGuia { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Vendedor IdVendedorNavigation { get; set; }
        public virtual ICollection<Despacho> Despachos { get; set; }
        public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; }
    }
}
