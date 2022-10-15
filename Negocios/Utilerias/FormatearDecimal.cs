using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Utilerias
{
   public static class FormatearDecimal
    {
        public static float Formatear(decimal numero)
        {
           return (float) Math.Round(numero, 2);
        }
    }
}
