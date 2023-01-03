using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Threading.Tasks;

namespace Negocios.Utilerias
{
    public static class AplicarDescuento
    {
        public static float Aplicar(float costo)
        {
            using (var dbContext = new AppDbContext())
            {
                var ValorDescuento = (from d in dbContext.Descuentos select d.Valor).First();

                return costo - ((ValorDescuento / 100) * costo);
            }
        }
    }
}
