using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades 

{
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Prompt ="Nombre")]
        public  string Nombre { get; set; }

        [Display(Name ="Código fabricante",Prompt = "Código fabricante")]
        public string CodFab { get; set; }

        [Display(Name = "Código proveedor", Prompt = "Código proveedor")]
        public string CodProv { get; set; }

        [Display(Name = "Descripción", Prompt = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Precio")]
        public float Precio { get; set; }

        [Display(Name = "Código SAT", Prompt = "Código SAT")]
        public string CodigoSat { get; set; }
    }
}
