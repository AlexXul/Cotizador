using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocios.CrudViewFacturaProducto
{
    public class LeerViewFacturaProductoPorFacturaId
    {
        public IEnumerable<ViewFacturaProducto> Leer(int idFactura)
        {
            using (var dbContext = new AppDbContext())
            {
                var consulta = from f in dbContext.ViewFacturaProductos
                               where f.FacturaId == idFactura 
                               select f;
                return consulta.ToList();
            }
        }
    }
}
