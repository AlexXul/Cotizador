﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaImpresion { get; set; }

        public bool Finalizado { get; set; } = false;

        [NotMapped]

        public String Folio { get; set; }
    }
}
