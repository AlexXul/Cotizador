using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudCotizacion
{
    public class LeerCotizacion
    {
        public IEnumerable<Cotizacion> Leer(int id)
        {
            using (var dbContext = new AppDbContext())
            {
                var consulta = from f in dbContext.Cotizaciones
                               join p in dbContext.Productos on f.ProductoId equals p.Id where f.FacturaId == id
                               select new Cotizacion
                               {
                                   Id = f.Id,
                                   ProductoId = p.Id,
                                   Producto = new Producto
                                   {
                                       Nombre = p.Nombre,
                                       CodFab = p.CodFab,
                                       CodProv = p.CodProv,
                                       Descripcion = p.Descripcion,
                                       CodigoSat = p.CodigoSat,
                                       Precio = p.Precio
                                   },
                                   Cantidad = f.Cantidad
                               };
                return consulta.ToList();
            }
        }
    }
}
