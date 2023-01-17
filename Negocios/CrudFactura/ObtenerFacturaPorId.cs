using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudFactura
{
    public class ObtenerFacturaPorId
    {
        public Factura Obtener(int id)
        {
            using (var dbContext = new AppDbContext())
            {
                var query = from f in dbContext.Facturas where f.Id == id select f;
                return query.FirstOrDefault();
                
            }
        }
    }
}
