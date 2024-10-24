using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AccesoDatos;
using Entidades.Models;
using Microsoft.Extensions.Configuration;

namespace AccesoDatos.DBContext
{
    public partial class RutinasContext : DbContext
    {

        private readonly IConfiguration _configuration;

        public RutinasContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public RutinasContext(DbContextOptions<RutinasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accion> Accions { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Parametro> Parametros { get; set; } = null!;
        public virtual DbSet<Rutina> Rutinas { get; set; } = null!;
        public virtual DbSet<RutinaAccion> RutinaAccions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var connectionString = _configuration.GetConnectionString("RutinasBD");
            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accion>(entity =>
            {
                entity.HasKey(e => e.IdAccion)
                    .HasName("PK__ejercici__F0E6D6050085D885");

                entity.ToTable("Accion");

                entity.Property(e => e.IdAccion).HasColumnName("idAccion");

                entity.Property(e => e.Creado)
                    .HasColumnType("datetime")
                    .HasColumnName("creado")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .HasColumnName("descripcion");

                entity.Property(e => e.GrupoMusculo)
                    .HasMaxLength(100)
                    .HasColumnName("grupoMusculo");

                entity.Property(e => e.NombreAccion)
                    .HasMaxLength(200)
                    .HasColumnName("nombreAccion");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__clientes__D5946642EB722EF3");

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Altura).HasColumnName("altura");

                entity.Property(e => e.Antecedente)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("antecedente");

                entity.Property(e => e.Creado)
                    .HasColumnType("datetime")
                    .HasColumnName("creado")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Disciplina)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("disciplina");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(100)
                    .HasColumnName("nombreCliente");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("sexo");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__clientes__usuarios__29572725");
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Parametro");

                entity.Property(e => e.Color1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("color1");

                entity.Property(e => e.Color2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("color2");

                entity.Property(e => e.ConsecutivoRutina).HasColumnName("consecutivoRutina");

                entity.Property(e => e.IdParametro).HasColumnName("idParametro");

                entity.Property(e => e.TipoImpresion).HasColumnName("tipoImpresion");
            });

            modelBuilder.Entity<Rutina>(entity =>
            {
                entity.HasKey(e => e.IdRutina)
                    .HasName("PK__rutinas__7C95EE408864D676");

                entity.ToTable("Rutina");

                entity.Property(e => e.IdRutina).HasColumnName("idRutina");

                entity.Property(e => e.Creado)
                    .HasColumnType("datetime")
                    .HasColumnName("creado")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fechaFin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.NombreRutina)
                    .HasMaxLength(255)
                    .HasColumnName("nombreRutina");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Rutinas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__rutinas__IdClien__47DBAE45");
            });

            modelBuilder.Entity<RutinaAccion>(entity =>
            {
                entity.HasKey(e => e.IdRutinaAccion)
                    .HasName("PK_rutina_acciones");

                entity.ToTable("RutinaAccion");

                entity.Property(e => e.IdRutinaAccion).HasColumnName("idRutinaAccion");

                entity.Property(e => e.IdAccion).HasColumnName("idAccion");

                entity.Property(e => e.IdRutina).HasColumnName("idRutina");

                entity.Property(e => e.PesoAccion).HasColumnName("pesoAccion");

                entity.Property(e => e.RepsAccion).HasColumnName("repsAccion");

                entity.Property(e => e.SetsAccion).HasColumnName("setsAccion");

                /*entity.HasOne(d => d.IdAccionNavigation)
                    .WithMany(p => p.RutinaAccions)
                    .HasForeignKey(d => d.IdAccion)
                    .HasConstraintName("FK__rutina_ej__IdEje__45F365D3");

                entity.HasOne(d => d.IdRutinaNavigation)
                    .WithMany(p => p.RutinaAccions)
                    .HasForeignKey(d => d.IdRutina)
                    .HasConstraintName("FK__rutina_ej__IdRut__46E78A0C");*/
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuarios__63C76BE249889CAB");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__usuarios__A9D10534C404021B")
                    .IsUnique();

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedNever()
                    .HasColumnName("idUsuario");

                entity.Property(e => e.Clave)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Creado)
                    .HasColumnType("datetime")
                    .HasColumnName("creado")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Rol).HasColumnName("rol");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .HasColumnName("telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
