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
        public void Eliminar(Cotizacion cotizacion)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Cotizaciones.Remove(cotizacion);
                dbContext.SaveChanges();
            }
        }
    }
}
