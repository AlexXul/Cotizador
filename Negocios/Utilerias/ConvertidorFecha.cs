using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Utilerias
{
    public static class ConvertidorFecha
    {
        public static DateTime ConvertToMexicanDate(DateTime Fecha)
        {
            string zonaHoraria = "Central Standard Time (Mexico)";
            DateTime FechaMexico = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Fecha, zonaHoraria);
            return FechaMexico;
        }
    }
}
