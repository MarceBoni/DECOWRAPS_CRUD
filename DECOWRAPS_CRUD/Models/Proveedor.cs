using System;
using System.Collections.Generic;

#nullable disable

namespace DECOWRAPS_CRUD.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        public int Nit { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int Activo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
