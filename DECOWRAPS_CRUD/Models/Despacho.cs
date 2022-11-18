using System;
using System.Collections.Generic;

#nullable disable

namespace DECOWRAPS_CRUD.Models
{
    public partial class Despacho
    {
        public int IdDespacho { get; set; }
        public int IdOrden { get; set; }
        public DateTime Fecha { get; set; }
        public string DireccionDestino { get; set; }
        public string CiudadDestino { get; set; }
        public string PaisDestino { get; set; }
        public string NoGuia { get; set; }
        public string Estado { get; set; }
        public string NomDestinatario { get; set; }
        public int IdTransportador { get; set; }

        public virtual OrdenDecowrap IdOrdenNavigation { get; set; }
        public virtual Transportadora IdTransportadorNavigation { get; set; }
    }
}
