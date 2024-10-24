

using Entidades.Models;

namespace LogicaNegocio.Interfaz
{
    public interface IRutinaAccionLN
    {
        List<RutinaAccion> recRutinaAccionPA();
        RutinaAccion recRutinaAccionPAXId(int pIdRutinaAccion);
        bool insRutinaAccionPA(RutinaAccion pRutinaAccion);
        bool modRutinaAccionPA(RutinaAccion pRutinaAccion);
        bool delRutinaAccionPA(RutinaAccion pRutinaAccion);
        
    }
}
