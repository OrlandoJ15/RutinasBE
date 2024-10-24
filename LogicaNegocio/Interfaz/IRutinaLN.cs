

using Entidades.Models;

namespace LogicaNegocio.Interfaz
{
    public interface IRutinaLN
    {
        List<Rutina> recRutinaPA();
        Rutina recRutinaPAXId(int pIdRutina);
        bool insRutinaPA(Rutina pRutina);
        bool modRutinaPA(Rutina pRutina);
        bool delRutinaPA(Rutina pRutina);
        
    }
}
