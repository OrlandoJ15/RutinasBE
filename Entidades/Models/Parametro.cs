using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class Parametro
    {
        public int? IdParametro { get; set; }
        public string Color1 { get; set; } = null!;
        public string Color2 { get; set; } = null!;
        public int? ConsecutivoRutina { get; set; }
        public int? TipoImpresion { get; set; }
    }
}
