using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence_.data
{
    public class AfiliadosCreditos
    {
        public float Taza { set; get; }

        [Key]
        public byte CreditoId { get; set; }
        public Creditos Credito { get; set; }

        [Key]
        public byte AfiliadoId { get; set; }
        public Afiliados Afiliados { get; set; }

    }
}
