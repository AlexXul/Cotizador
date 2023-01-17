using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocios.CrudDescuento
{
    public class LectorDescuento
    {
        public Descuento Leer()
        {
            using (var dbContext = new AppDbContext())
            {
                var consulta = from p in dbContext.Descuentos select p;
                return consulta.FirstOrDefault();
            }
        }
    }
}
