using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudIVA
{
   public class CrearIVA
    {
        public void Crear(IVA d) 
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.IVAs.Add(d);
                dbContext.SaveChanges();
            }
        }

   }
}
