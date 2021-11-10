using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Hotel_Passagem.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public virtual DbSet<Hotel> Hoteis { get; set; }
        public virtual DbSet<Quarto> Quartos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var sqlConnection = "Data Source=DESKTOP-8CO6RMG\\SQLEXPRESS2019;Initial Catalog=banco_hoteis;Integrated Security=True";

                optionsBuilder.UseSqlServer(sqlConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheckIn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("check_in");

                entity.Property(e => e.CheckOut)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("check_out");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.Estacionamento).HasColumnName("estacionamento");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Quarto>(entity =>
            {
                entity.ToTable("Quarto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdHotel).HasColumnName("id_hotel");

                entity.Property(e => e.InfoQuarto)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("info_quarto");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdHotelNavigation)
                    .WithMany(p => p.Quartos)
                    .HasForeignKey(d => d.IdHotel)
                    .HasConstraintName("FK_Hotel_Quarto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
