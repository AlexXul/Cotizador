using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudCotizacion
{
    public class CrearCotizacion
    {
        public void Crear(Cotizacion cotizacion)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Cotizaciones.Add(cotizacion);
                dbContext.SaveChanges();
            }
        }
    }
}
