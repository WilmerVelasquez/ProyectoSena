using ProyectoSena.Domain;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoSena.Core.Domain
{
    public partial class RegistroIngreso
    {
        public int IdRegistro { get; set; }
        public string NombreRegistro { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int IdUsuario { get; set; }
        public int IdHorario { get; set; }

        public virtual Horarios IdHorarioNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
