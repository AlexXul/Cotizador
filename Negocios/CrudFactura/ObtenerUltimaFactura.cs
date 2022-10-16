using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudFactura
{
    public class ObtenerUltimaFactura
    {
        public Factura Obtener()
        {
            using (var dbContext = new AppDbContext())
            {
                var query = from f in dbContext.Facturas orderby f.Fecha descending select f;
                return query.FirstOrDefault();
                
            }
        }
    }
}
