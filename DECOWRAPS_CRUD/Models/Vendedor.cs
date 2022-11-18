using System;
using System.Collections.Generic;

#nullable disable

namespace DECOWRAPS_CRUD.Models
{
    public partial class Vendedor
    {
        public Vendedor()
        {
            OrdenDecowraps = new HashSet<OrdenDecowrap>();
        }

        public int IdVendedor { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Zona { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Activo { get; set; }

        public virtual ICollection<OrdenDecowrap> OrdenDecowraps { get; set; }
    }
}
