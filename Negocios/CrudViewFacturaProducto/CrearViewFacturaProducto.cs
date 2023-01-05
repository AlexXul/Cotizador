using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocios.CrudViewFacturaProducto
{
    public class CrearViewFacturaProducto
    {
        public void Crear(ViewFacturaProducto producto)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.ViewFacturaProductos.Add(producto);
                dbContext.SaveChanges();
            }
        }
    }
}
