using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaz
{
    public interface IAccionAD
    {
        
        List<Accion> recAccionPA();
        Accion recAccionPAXId(int pIdAccion);
        bool insAccionPA(Accion pAccionPA);
        bool modAccionPA(Accion pAccionPA);
        bool delAccionPA(Accion pRAccionPA);
        
    }
}
