using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudFactura
{
    public class EliminarFactura
    {
        public void Eliminar(Factura factura)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Facturas.Remove(factura);
                dbContext.SaveChanges();
            }
        }
    }
}
