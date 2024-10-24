using System;
using System.Collections.Generic;

namespace  Entidades.Models

{
    public partial class Accion
    {
        public Accion()
        {
            RutinaAccions = new HashSet<RutinaAccion>();
        }

        public int IdAccion { get; set; }
        public string NombreAccion { get; set; } = null!;
        public string? GrupoMusculo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Creado { get; set; }

        public virtual ICollection<RutinaAccion> RutinaAccions { get; set; }
    }
}
