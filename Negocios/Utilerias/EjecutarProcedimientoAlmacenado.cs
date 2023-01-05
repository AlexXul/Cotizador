using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Negocios.Utilerias
{
   public static class EjecutarProcedimientoAlmacenado
    {
        public static void Ejecutar(string procedimiento)
        {
            //SqlConnection con = new SqlConnection("workstation id=DbTester.mssql.somee.com;packet size=4096;user id=daniel_123_SQLLogin_1;pwd=lx8u4atmdy;data source=DbTester.mssql.somee.com;persist security info=False;initial catalog=DbTester ;Trust Server Certificate=true");
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-TU4DNU1R;Initial Catalog=DbCotizador;Integrated Security=true ;Trust Server Certificate=true");
            SqlCommand command1 = new SqlCommand();

            command1.CommandText = procedimiento;
            command1.CommandType = CommandType.StoredProcedure;
            command1.Connection = con;
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
        }
    }
}
