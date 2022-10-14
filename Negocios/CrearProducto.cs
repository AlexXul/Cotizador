using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
   public class CrearProducto
    {
        public void Crear(Producto producto) 
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Productos.Add(producto);
                dbContext.SaveChanges();
            }
        }

    }
}
