using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoSena.Core.Domain
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int? CantidadDisponible { get; set; }
        public string Medidas { get; set; }
        public int IdSuministro { get; set; }

        public virtual Suministro IdSuministroNavigation { get; set; }
    }
}
