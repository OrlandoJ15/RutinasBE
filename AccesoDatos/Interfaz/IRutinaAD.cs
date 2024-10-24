using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaz
{
    public interface IRutinaAD
    {
        
        List<Rutina> recRutinaPA();
        Rutina recRutinaPAXId(int pIdRutina);
        bool insRutinaPA(Rutina pRutinaPA);
        bool modRutinaPA(Rutina pRutinaPA);
        bool delRutinaPA(Rutina pRutinaPA);
        
    }
}
