using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaz
{
    public interface IRutinaAccionAD
    {
        
        List<RutinaAccion> recRutinaAccionPA();
        RutinaAccion recRutinaAccionPAXId(int pIdRutinaAccion);
        bool insRutinaAccionPA(RutinaAccion pRutinaAccionPA);
        bool modRutinaAccionPA(RutinaAccion pRutinaAccionPA);
        bool delRutinaAccionPA(RutinaAccion pRutinaAccionPA);
        
    }
}
