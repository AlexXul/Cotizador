using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudProducto
{
   public class LeerProducto
    {
        public IEnumerable<Producto> Leer()
        {
            using (var dbContext = new AppDbContext())
            {
               var consulta = from p in dbContext.Productos select p;
                return consulta.ToList();
            }
        }
    }
}
