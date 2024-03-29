﻿using ProyectoSena.Domain;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoSena.Core.Domain
{
    public partial class Usuario
    {
        public Usuario()
        {
            RegistroIngreso = new HashSet<RegistroIngreso>();
        }

        public int IdUsuario { get; set; }
        public int? NDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public int IdEstado { get; set; }
        public int IdSolicitud { get; set; }
        public int? IdHorario { get; set; }
        public virtual Horarios IdHorarioNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Solicitud IdSolicitudNavigation { get; set; }
        public virtual ICollection<RegistroIngreso> RegistroIngreso { get; set; }
    }
}
