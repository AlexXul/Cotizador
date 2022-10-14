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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = "Data Source=LAPTOP-TU4DNU1R;Initial Catalog=DbCotizador;Integrated Security=true";
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
