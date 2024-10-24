

using Entidades.Models;

namespace LogicaNegocio.Interfaz
{
    public interface IParametroLN
    {
        List<Parametro> recParametroPA();
        Parametro recParametroPAXId(int pIdParametro);
        bool modParametroPA(Parametro pParametro);
        
    }
}
