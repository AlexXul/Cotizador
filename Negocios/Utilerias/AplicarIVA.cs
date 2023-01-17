using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;
using Negocios.CrudIVA;
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
            float ValorIVA = 0;
            IVA i = new LectorIVA().Leer();
            if (i != null)
                ValorIVA = i.Valor;
            return ValorIVA;
        }
    }
}
