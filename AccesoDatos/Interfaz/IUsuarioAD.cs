using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaz
{
    public interface IUsuarioAD
    {
        
        List<Usuario> recUsuarioPA();
        Usuario recUsuarioPAXId(int pIdUsuario);
        bool insUsuarioPA(Usuario pUsuarioPA);
        bool modUsuarioPA(Usuario pUsuarioPA);
        bool delUsuarioPA(Usuario pUsuarioPA);
        
    }
}
