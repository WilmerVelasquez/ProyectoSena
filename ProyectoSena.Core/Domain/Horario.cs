using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoSena.Core.Domain
{
    public partial class Horario
    {
        public int IdHorario { get; set; }
        public string NombreHorario { get; set; }
        public DateTime? FranjaHoraria { get; set; }
    }
}
