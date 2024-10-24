

using Entidades.Models;

namespace LogicaNegocio.Interfaz
{
    public interface IUsuarioLN
    {
        List<Usuario> recUsuarioPA();
        Usuario recUsuarioPAXId(int pIdUsuario);
        bool insUsuarioPA(Usuario pUsuario);
        bool modUsuarioPA(Usuario pUsuario);
        bool delUsuarioPA(Usuario pUsuario);
        
    }
}
