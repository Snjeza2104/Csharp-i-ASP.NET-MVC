using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebShop.Models
{
    public partial class WebShop_model : DbContext
    {
        public WebShop_model()
            : base("name=WebShopModel")
        {
        }

        public virtual DbSet<Kategorije> Kategorije { get; set; }
        public virtual DbSet<KategorijeProizvodi> KategorijeProizvodi { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<MjereProizvoda> MjereProizvoda { get; set; }
        public virtual DbSet<Narudzbe> Narudzbe { get; set; }
        public virtual DbSet<NarudzbeDetalji> NarudzbeDetalji { get; set; }
        public virtual DbSet<Proizvodi> Proizvodi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategorije>()
                .HasMany(e => e.KategorijeProizvodi)
                .WithRequired(e => e.Kategorije)
                .HasForeignKey(e => e.KategorijaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korisnici>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnici>()
                .Property(e => e.Kontakt)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnici>()
                .HasMany(e => e.Narudzbe)
                .WithRequired(e => e.Korisnici)
                .HasForeignKey(e => e.KorisnikId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MjereProizvoda>()
                .HasMany(e => e.Proizvodi)
                .WithRequired(e => e.MjereProizvoda)
                .HasForeignKey(e => e.MjeraProizvodaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Narudzbe>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Narudzbe>()
                .HasMany(e => e.NarudzbeDetalji)
                .WithOptional(e => e.Narudzbe)
                .HasForeignKey(e => e.NarudzbaId);

            modelBuilder.Entity<Proizvodi>()
                .Property(e => e.Naziv)
                .IsUnicode(false);

            modelBuilder.Entity<Proizvodi>()
                .HasMany(e => e.KategorijeProizvodi)
                .WithRequired(e => e.Proizvodi)
                .HasForeignKey(e => e.ProizvodId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proizvodi>()
                .HasMany(e => e.NarudzbeDetalji)
                .WithOptional(e => e.Proizvodi)
                .HasForeignKey(e => e.ProizvodId);
        }
    }
}
