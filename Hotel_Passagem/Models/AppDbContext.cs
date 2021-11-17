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

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Companhia> Companhia { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Passagem> Passagems { get; set; }
        public virtual DbSet<Quarto> Quartos { get; set; }
        public virtual DbSet<ReservaQuarto> ReservaQuartos { get; set; }
        public virtual DbSet<VendaPassagem> VendaPassagems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=RODRIGO-PC\\SQLEXPRESS;Database=test;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Companhia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

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

                entity.Property(e => e.Estacionamento).HasColumnName("estacionamento");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Passagem>(entity =>
            {
                entity.ToTable("Passagem");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataReserva)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("data_reserva");

                entity.Property(e => e.Destino)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("destino");

                entity.Property(e => e.Embarque)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("embarque");

                entity.Property(e => e.IdCompanhia).HasColumnName("id_companhia");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("valor");
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

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<ReservaQuarto>(entity =>
            {
                entity.ToTable("Reserva_Quarto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataEntrada)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("data_entrada");

                entity.Property(e => e.DataSaida)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("data_saida");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdQuarto).HasColumnName("id_quarto");
            });

            modelBuilder.Entity<VendaPassagem>(entity =>
            {
                entity.ToTable("Venda_Passagem");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdPassagem).HasColumnName("id_passagem");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
