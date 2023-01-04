using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudDescuento
{
   public class CrearDescuento
    {
        public void Crear(Descuento d) 
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Descuentos.Add(d);
                dbContext.SaveChanges();
            }
        }

   }
}
