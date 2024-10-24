using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public DateTime? Creado { get; set; }
        public string? Clave { get; set; }
        public int? Rol { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
