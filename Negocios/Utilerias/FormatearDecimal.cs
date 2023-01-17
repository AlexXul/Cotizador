using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Utilerias
{
    public static class FormatearDecimal
    {
        public static float Formatear(string numero)
        {
            string resultado = "";
            if(numero.Split(".").Length == 2)
            {
                resultado += (numero.Split(".")[0] + ".");
                resultado += (numero.Split(".")[1].Length > 2) ? numero.Split(".")[1].Substring(0, 2) : numero.Split(".")[1];
            }
            else
            {
                resultado = numero;
            }
            return float.Parse(resultado);
        }
    }
}
