using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudFactura
{
    public class EditarFactura
    {
        public void Editar(Factura factura)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Facturas.Update(factura);
                dbContext.SaveChanges();
            }
        }
    }
}
