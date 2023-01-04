using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocios.CrudFactura
{
   public class ObtenerFacturas
    {
        public  IEnumerable<Factura> Obtener()
        {
            using (var dbContext = new AppDbContext())
            {
                var consulta = from p in dbContext.Facturas select p;
                return consulta.ToList();
            }
        }
    }
}
