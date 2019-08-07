using System;
using System.Collections.Generic;

namespace Persistence_.data
{
    public partial class Creditos
    {
        public byte Id { get; set; }
        public string Credito { get; set; }

        public List<AfiliadosCreditos> AfiliadosCreditos { get; set; }
    }
}
