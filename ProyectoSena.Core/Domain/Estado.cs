using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoSena.Core.Domain
{
    public partial class Estado
    {
        public Estado()
        {
            Solicitud = new HashSet<Solicitud>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }

        public virtual ICollection<Solicitud> Solicitud { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
