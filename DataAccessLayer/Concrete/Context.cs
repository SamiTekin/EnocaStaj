using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API ile ilişkileri tanımlayın
            modelBuilder.Entity<Firma>()
                .HasMany(f => f.Urunler)
                .WithOne(u => u.Firma)
                .HasForeignKey(u => u.FirmaId);

            modelBuilder.Entity<Siparis>()
                .HasOne(s => s.Firma)
                .WithMany()
                .HasForeignKey(s => s.FirmaId);

            modelBuilder.Entity<Siparis>()
                .HasOne(s => s.Urun)
                .WithMany()
                .HasForeignKey(s => s.UrunId);
        }
    }
}
