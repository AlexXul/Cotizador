using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Threading.Tasks;

namespace Negocios.Utilerias
{
    public static class AplicarIVA
    {
        public static float Aplicar(float costo)
        {
            using (var dbContext = new AppDbContext())
            {
                float ValorIVA = ObtenerIVA();

                return costo + ((ValorIVA / 100) * costo);
            }
        }
        public static float ObtenerIVA()
        {
            using (var dbContext = new AppDbContext())
            {
                float ValorIVA = (from d in dbContext.IVAs select d.Valor).First();

                return ValorIVA;
            }
        }
    }
}
