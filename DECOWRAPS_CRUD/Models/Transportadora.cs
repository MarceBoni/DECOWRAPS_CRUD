using System;
using System.Collections.Generic;

#nullable disable

namespace DECOWRAPS_CRUD.Models
{
    public partial class Transportadora
    {
        public Transportadora()
        {
            Despachos = new HashSet<Despacho>();
        }

        public int IdTransportador { get; set; }
        public string Nombre { get; set; }
        public int Nit { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public int Activo { get; set; }
        public string PaginaWeb { get; set; }

        public virtual ICollection<Despacho> Despachos { get; set; }
    }
}
