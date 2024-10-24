using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaz
{
    public interface IParametroAD
    {
        
        List<Parametro> recParametroPA();
        Parametro recParametroPAXId(int pIdParametro);
        bool modParametroPA(Parametro pParametroPA);
        
    }
}
