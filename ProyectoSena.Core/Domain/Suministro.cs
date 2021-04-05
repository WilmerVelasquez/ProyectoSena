using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoSena.Core.Domain
{
    public partial class Suministro
    {
        public int IdSuministro { get; set; }
        public string NombreSuministro { get; set; }
        public int? IdSolicitud { get; set; }
    }
}
