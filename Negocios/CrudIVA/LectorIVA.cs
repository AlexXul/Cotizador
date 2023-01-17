using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocios.CrudIVA
{
    public class LectorIVA
    {
        public IVA Leer()
        {
            using (var dbContext = new AppDbContext())
            {
                var consulta = from p in dbContext.IVAs select p;
                return consulta.FirstOrDefault();
            }
        }
    }
}
