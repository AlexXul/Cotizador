using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocios.Utilerias;
using Entidades;
using AccesoDatos;


namespace Negocios.CrudFactura
{
    public class EliminarFactura
    {
        public void Eliminar(Factura factura)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Facturas.Remove(factura);
                dbContext.SaveChanges();
                EjecutarProcedimientoAlmacenado.Ejecutar("ReestablecerIdFacturas");


            }
        }
    }
}
