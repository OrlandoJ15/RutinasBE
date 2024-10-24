

using Entidades.Models;

namespace LogicaNegocio.Interfaz
{
    public interface IAccionLN
    {
        List<Accion> recAccionPA();
        Accion recAccionPAXId(int pIdAccion);
        bool insAccionPA(Accion pAccion);
        bool modAccionPA(Accion pAccion);
        bool delAccionPA(Accion pAccion);
        
    }
}
