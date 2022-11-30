using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudProducto
{
    public class ObtenerPrecioProductoPorId
    {
        public float Obtener(int id)
        {
            using (var dbContext = new AppDbContext())
            {
               var consulta = from p in dbContext.Productos where p.Id == id select p;
                return consulta.First().Precio;
            }
        }
    }
}
