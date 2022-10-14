using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class EditarProducto
    {
        public void Editar(Producto producto)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Productos.Update(producto);
                dbContext.SaveChanges();
            }
        }
    }
}
