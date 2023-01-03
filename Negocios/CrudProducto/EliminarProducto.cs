using AccesoDatos;
using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.CrudProducto
{
    public class EliminarProducto
    {
        public void Eliminar(Producto producto)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Productos.Remove(producto);
                dbContext.SaveChanges();
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-TU4DNU1R;Initial Catalog=DbCotizador;Integrated Security=true ;Trust Server Certificate=true");
                SqlCommand command1 = new SqlCommand();

                command1.CommandText = "ReestablecerIdProductos";
                command1.CommandType = CommandType.StoredProcedure;
                command1.Connection = con;
                con.Open();
                command1.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}
