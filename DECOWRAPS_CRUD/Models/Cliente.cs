using System;
using System.Collections.Generic;

#nullable disable

namespace DECOWRAPS_CRUD.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            CatalogoClientes = new HashSet<CatalogoCliente>();
            OrdenDecowraps = new HashSet<OrdenDecowrap>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public int NoIdentificacion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public int Activo { get; set; }

        public virtual ICollection<CatalogoCliente> CatalogoClientes { get; set; }
        public virtual ICollection<OrdenDecowrap> OrdenDecowraps { get; set; }
    }
}
