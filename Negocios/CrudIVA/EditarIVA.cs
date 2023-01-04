using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocios.CrudIVA
{
    public class EditarIVA
    {
        public void Editar(IVA d)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.IVAs.Update(d);
                dbContext.SaveChanges();
            }
        }
    }
}
