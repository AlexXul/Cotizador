using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
namespace Entidades 

{
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public  string Nombre { get; set; }

        public string CodFab { get; set; }
        public string CodProv { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string CodigoSat { get; set; }
    }
}
