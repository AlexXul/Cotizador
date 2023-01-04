using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocios.CrudDescuento
{
    public class EditarIVA
    {
        public void Editar(Descuento d)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Descuentos.Update(d);
                dbContext.SaveChanges();
            }
        }
    }
}
