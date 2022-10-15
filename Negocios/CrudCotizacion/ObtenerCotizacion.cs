using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudCotizacion
{
    public class ObtenerCotizacion
    {
        public Cotizacion Obtener(int id)
        {
            using (var dbContext = new AppDbContext())
            {
                var consulta = from f in dbContext.Facturas where f.Id == id select f;
                return consulta.FirstOrDefault();
            }
        }
    }
}
