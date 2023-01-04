using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocios.CrudDescuento
{
    public class EliminarDescuento
    {
        public void Eliminar(Descuento d)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Descuentos.Remove(d);
                dbContext.SaveChanges();
            }
        }
    }
}
