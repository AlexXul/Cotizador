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
        public bool ObtenerExistencia(int id,int idFactura)
        {
            using (var dbContext = new AppDbContext())
            {
                var consulta = from f in dbContext.Cotizaciones where f.ProductoId == id && f.FacturaId == idFactura select f ;
                return consulta.Any();
            }
        }
    }
}
