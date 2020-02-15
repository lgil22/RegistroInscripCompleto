using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroP.UI.Registros
{
    public static class Convertidor
    {
        public static int ToInt(this string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);
            return retorno;
        }
    }
}
