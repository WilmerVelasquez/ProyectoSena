using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoSena.Core.Domain
{
    public partial class Solicitud
    {
        public Solicitud()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdSolicitud { get; set; }
        public string NombreSolicitud { get; set; }
        public DateTime? FechaCreada { get; set; }
        public string FechaRespuesta { get; set; }
        public int IdSuministro { get; set; }
        public int IdEstado { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Suministro IdSuministroNavigation { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
