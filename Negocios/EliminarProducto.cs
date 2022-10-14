﻿using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class EliminarProducto
    {
        public void Eliminar(Producto producto)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Productos.Remove(producto);
                dbContext.SaveChanges();
            }
        }
    }
}
