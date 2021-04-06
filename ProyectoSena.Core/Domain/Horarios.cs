using ProyectoSena.Core.Domain;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoSena.Domain
{
    public partial class Horarios
    {
        public Horarios()
        {
            RegistroIngreso = new HashSet<RegistroIngreso>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdHorario { get; set; }
        public string NombreHorario { get; set; }
        public DateTime? FranjaHoraria { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<RegistroIngreso> RegistroIngreso { get; set; }
    }
}
