using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class Rutina
    {
        public Rutina()
        {
            RutinaAccions = new HashSet<RutinaAccion>();
        }

        public int IdRutina { get; set; }
        public int? IdCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? NombreRutina { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? Creado { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual ICollection<RutinaAccion> RutinaAccions { get; set; }
    }
}
