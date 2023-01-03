using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocios.CrudProducto
{
   public class ObtenerProductoPorDatos
    {
       public Producto Obtener(Producto p)
        {
            using (var dbContext = new AppDbContext())
            {
                var query = from productos in dbContext.Productos
                           where p.CodProv == productos.CodProv
                           && p.CodFab == productos.CodFab
                           && p.CodigoSat == productos.CodigoSat
                           && p.Nombre == productos.Nombre
                           select productos;
                return query.FirstOrDefault();
           
            }
        }
    }

}
