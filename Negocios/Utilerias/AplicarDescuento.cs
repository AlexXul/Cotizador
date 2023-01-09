using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;
using Negocios.CrudDescuento;
using System.Threading.Tasks;

namespace Negocios.Utilerias
{
    public static class AplicarDescuento
    {
        public static float Aplicar(float costo)
        {
            using (var dbContext = new AppDbContext())
            {
                var ValorDescuento = ObtenerDescuento();

                return costo - ((ValorDescuento / 100) * costo);
            }
        }
        public static float ObtenerDescuento()
        {
            float ValorDescuento = 0;
            Descuento d = new LectorDescuento().Leer();
            if (d != null)
                ValorDescuento = d.Valor;
            return ValorDescuento;
        }
    }
}
