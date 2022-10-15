using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudCotizacion
{
    public class ObtenerExistenciaProductoEnCotizacion
    {
        public bool ObtenerExistencia(int id)
        {
            using (var dbContext = new AppDbContext())
            {
                var consulta = from f in dbContext.Facturas where f.ProductoId == id select f;
                return consulta.Any();
            }
        }
    }
}
