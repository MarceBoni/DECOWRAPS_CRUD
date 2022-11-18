using System;
using System.Collections.Generic;

#nullable disable

namespace DECOWRAPS_CRUD.Models
{
    public partial class CatalogoCliente
    {
        public CatalogoCliente()
        {
            Catalogos = new HashSet<Catalogo>();
        }

        public int CodCatalogo { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int Activo { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Catalogo> Catalogos { get; set; }
    }
}
