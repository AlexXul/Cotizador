using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudCotizacion
{
    public class EditarCotizacion
    {
        public void Editar(Cotizacion cotizacion)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Cotizaciones.Update(cotizacion);
                dbContext.SaveChanges();
            }
        }
    }
}
