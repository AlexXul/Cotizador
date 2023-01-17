using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AppDbContext: DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cotizacion> Cotizaciones { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Descuento> Descuentos { get; set; }
        public DbSet<IVA> IVAs { get; set; }
        public DbSet<ViewFacturaProducto> ViewFacturaProductos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
<<<<<<< HEAD
                string connectionString = "Data Source=LAPTOP-TU4DNU1R;Initial Catalog=DbCotizador;Integrated Security=true";
               // connectionString = "Data Source=LAPTOP-MO1HC59V;Initial Catalog=DbCotizador;Integrated Security=true";
=======
                string connectionString = "Data Source=LAPTOP-TU4DNU1R;Initial Catalog=DbCotizador;Integrated Security=true ;Trust Server Certificate=true";
                //connectionString = "Data Source=LAPTOP-MO1HC59V;Initial Catalog=DbCotizador;Integrated Security=true";
                //connectionString = "workstation id=DbTester.mssql.somee.com;packet size=4096;user id=daniel_123_SQLLogin_1;pwd=lx8u4atmdy;data source=DbTester.mssql.somee.com;persist security info=False;initial catalog=DbTester ;Trust Server Certificate=true";
>>>>>>> aee79f3fcaaa19f03db56cf7412eb4384a4a87e0
                options.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder pModelBuilder)
        {
            base.OnModelCreating(pModelBuilder);
            //aquí se personalizan las tablas

        }
    }
}
