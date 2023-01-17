using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Utilerias
{
   public static class GeneradorFolio
    {
        public static string Generar(int id)
        {
            return id.ToString().PadLeft(5,'0');
        }
    }
}
