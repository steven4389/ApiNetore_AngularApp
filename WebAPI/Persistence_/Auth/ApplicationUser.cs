using Microsoft.AspNetCore.Identity;
using Persistence_.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Persistence_.Auth
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName ="nvarchar(150)")]
        public string FullName { get; set; }

        public ICollection<Afiliados> Afiliados { get; set; }
    }
}
