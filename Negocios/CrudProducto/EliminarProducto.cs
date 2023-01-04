using AccesoDatos;
using Entidades;
using Negocios.Utilerias;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudProducto
{
    public class EliminarProducto
    {
        public void Eliminar(Producto producto)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Productos.Remove(producto);
                dbContext.SaveChanges();
                EjecutarProcedimientoAlmacenado.Ejecutar("RestablecerIdProductos");
                

            }
        }
    }
}
