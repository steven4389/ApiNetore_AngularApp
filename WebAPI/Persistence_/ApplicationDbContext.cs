using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence_.Auth;
using Persistence_.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Persistence_
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AfiliadosCreditos>().HasKey(x => new { x.CreditoId, x.AfiliadoId });

            modelBuilder.Entity<AfiliadosCreditos>()
             .HasOne(x => x.Afiliados)
             .WithMany(x => x.AfiliadosCreditos)
             .HasForeignKey(x => x.AfiliadoId);

            modelBuilder.Entity<AfiliadosCreditos>()
               .HasOne(x => x.Credito)
               .WithMany(x => x.AfiliadosCreditos)
               .HasForeignKey(x => x.CreditoId);

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Afiliados> Afiliados { get; set; }
        public DbSet<Creditos> Creditos { get; set; }
        public DbSet<AfiliadosCreditos> AfiliadosCreditos { get; set; }
    }
}
