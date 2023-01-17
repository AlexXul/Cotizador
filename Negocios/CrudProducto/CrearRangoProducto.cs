using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudProducto
{
   public class CrearRangoProducto
    {
        public void Crear(IEnumerable<Producto> productos) 
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Productos.AddRange(productos);
                dbContext.SaveChanges();
            }
        }

    }
}
