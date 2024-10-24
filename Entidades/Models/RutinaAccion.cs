using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class RutinaAccion
    {
        public int IdRutina { get; set; }
        public int IdAccion { get; set; }
        public int? SetsAccion { get; set; }
        public int? RepsAccion { get; set; }
        public int? PesoAccion { get; set; }
        public int IdRutinaAccion { get; set; }

        public virtual Accion? IdAccionNavigation { get; set; } = null!;
        public virtual Rutina? IdRutinaNavigation { get; set; } = null!;
    }
}
