using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class BuscadorProducto
    {
        public Producto Buscar(string buscado)
        {
            using (var dbContext = new AppDbContext())
            {
                var consulta = from p in dbContext.Productos where p.Nombre.StartsWith(buscado) select
                               new Producto { 
                                   Nombre = p.Nombre,
                                   Id = p.Id
                               };
                             
                return consulta.FirstOrDefault();
            }
        }
    }
}
