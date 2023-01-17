using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocios.CrudViewFacturaProducto
{
    public class LeerViewFacturaProducto
    {
        public IEnumerable<ViewFacturaProducto> Leer()
        {
            using (var dbContext = new AppDbContext())
            {
                var consulta = from f in dbContext.ViewFacturaProductos
                               select f;
                return consulta.ToList();
            }
        }
    }
}
