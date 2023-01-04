using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocios.CrudFactura
{
   public class ObtenerProductosIdFactura
    {
        public IEnumerable<Cotizacion> Obtener( int idFactura)
        {
            using (var dbContext = new AppDbContext())
            {
                var consulta = from f in dbContext.Facturas
                               join c in dbContext.Cotizaciones on f.Id equals c.FacturaId
                               join p in dbContext.Productos on c.ProductoId equals p.Id
                               where f.Id == idFactura
                               select new Cotizacion
                               { Id = c.Id,
                                   Factura = new Factura
                                   { Id = f.Id,
                                   
                                   FechaCreacion = f.FechaCreacion,
                                   FechaImpresion= f.FechaImpresion,
                                   Finalizado= f.Finalizado
                                    },
                                Cantidad = c.Cantidad,
                                SubTotal = c.SubTotal,
                                FacturaId = f.Id,
                                Producto = new Producto 
                                    { Id =f.Id,
                                    Nombre = p.Nombre,
                                    Precio = p.Precio,
                                    Descripcion = p.Descripcion,
                                    CodigoSat = p.CodigoSat


                                     }

                           
                               
                               };
               
                                 

                return consulta.ToList();
            }
        }

    }
}
