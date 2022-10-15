using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudCotizacion
{
    public class EliminarCotizacion
    {
        public void Eliminar(Cotizacion factura)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Facturas.Remove(factura);
                dbContext.SaveChanges();
            }
        }
    }
}
