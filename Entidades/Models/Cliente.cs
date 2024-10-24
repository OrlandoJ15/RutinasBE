using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Rutinas = new HashSet<Rutina>();
        }

        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public string NombreCliente { get; set; } = null!;
        public string? NombreUsuario { get; set; } = null!;
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public DateTime? Creado { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; } = null!;
        public string? Disciplina { get; set; }
        public string? Antecedente { get; set; }
        public string? Descripcion { get; set; }
        public int? Altura { get; set; }
        public int? Peso { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Rutina> Rutinas { get; set; }
    }
}
