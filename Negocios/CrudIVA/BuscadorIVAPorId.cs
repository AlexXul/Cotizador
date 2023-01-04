using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocios.CrudIVA
{
    public class BuscadorIVAPorId
    {
        public IVA Buscar(int id)
        {
            using (var dbContext = new AppDbContext())
            {
                var consulta = from p in dbContext.IVAs where p.Id == id select p;
                return consulta.FirstOrDefault();
            }
        }
    }
}
