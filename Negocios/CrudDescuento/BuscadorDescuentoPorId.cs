using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocios.CrudDescuento
{
    public class BuscadorIVAPorId
    {
        public Descuento Buscar(int id)
        {
            using (var dbContext = new AppDbContext())
            {
                var consulta = from p in dbContext.Descuentos where p.Id == id select p;
                return consulta.FirstOrDefault();
            }
        }
    }
}
