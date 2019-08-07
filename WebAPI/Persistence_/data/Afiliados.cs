using Persistence_.Auth;
using System;
using System.Collections.Generic;

namespace Persistence_.data
{
    public partial class Afiliados
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public byte Cedula { get; set; }
        public string Estado { get; set; }
        public string AdminId { get; set; }

        public ApplicationUser Admin { get; set; }

        public List<AfiliadosCreditos> AfiliadosCreditos { get; set; }
    }
}
