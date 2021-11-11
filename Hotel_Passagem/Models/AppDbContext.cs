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
        public virtual DbSet<Companhia> Companhias { get; set; }
        public virtual DbSet<Hotel> Hoteis { get; set; }
        public virtual DbSet<Passagem> Passagens { get; set; }
        public virtual DbSet<Quarto> Quartos { get; set; }
        public virtual DbSet<ReservaQuarto> ReservaQuartos { get; set; }
        public virtual DbSet<VendaPassagem> VendaPassagems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-8CO6RMG\\SQLEXPRESS2019;Initial Catalog=banco_hoteis;Integrated Security=True");
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

                entity.Property(e => e.IdPassagem).HasColumnName("id_passagem");

                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdPassagemNavigation)
                    .WithMany(p => p.Companhia)
                    .HasForeignKey(d => d.IdPassagem)
                    .HasConstraintName("FK_Companhia_Passagem");
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

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdHotelNavigation)
                    .WithMany(p => p.Quartos)
                    .HasForeignKey(d => d.IdHotel)
                    .HasConstraintName("FK_Hotel_Quarto");
            });

            modelBuilder.Entity<ReservaQuarto>(entity =>
            {
                entity.ToTable("Reserva_Quarto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataEntrada)
                    .HasColumnType("date")
                    .HasColumnName("data_entrada");

                entity.Property(e => e.DataSaida)
                    .HasColumnType("date")
                    .HasColumnName("data_saida");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdQuarto).HasColumnName("id_quarto");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ReservaQuartos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_ReservaQuarto_Cliente");

                entity.HasOne(d => d.IdQuartoNavigation)
                    .WithMany(p => p.ReservaQuartos)
                    .HasForeignKey(d => d.IdQuarto)
                    .HasConstraintName("FK_ReservaQuarto_Quarto");
            });

            modelBuilder.Entity<VendaPassagem>(entity =>
            {
                entity.ToTable("Venda_Passagem");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdPassagem).HasColumnName("id_passagem");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.VendaPassagems)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_VendaPassagem_Cliente");

                entity.HasOne(d => d.IdPassagemNavigation)
                    .WithMany(p => p.VendaPassagems)
                    .HasForeignKey(d => d.IdPassagem)
                    .HasConstraintName("FK_VendaPassagem_Passagem");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
