using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmatchAppEv2.Models;

public partial class SmatchAppEv2DbContext : DbContext
{
    public SmatchAppEv2DbContext()
    {
    }

    public SmatchAppEv2DbContext(DbContextOptions<SmatchAppEv2DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<ConfirmarUsuario> ConfirmarUsuarios { get; set; }

    public virtual DbSet<CrearSesion> CrearSesions { get; set; }

    public virtual DbSet<Deporte> Deportes { get; set; }

    public virtual DbSet<Lugar> Lugars { get; set; }

    public virtual DbSet<Notificacion> Notificacions { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.\\sqlexpress; initial catalog=smatchAppEv2DB; trusted_connection=True; encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.IdChat).HasName("PK__Chat__68D484D194760A81");

            entity.ToTable("Chat");

            entity.Property(e => e.IdChat).HasColumnName("id_chat");
            entity.Property(e => e.IdSala).HasColumnName("id_sala");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("mensaje");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Chats)
                .HasForeignKey(d => d.IdSala)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Chat__id_sala__4CA06362");
        });

        modelBuilder.Entity<ConfirmarUsuario>(entity =>
        {
            entity.HasKey(e => e.IdConfirmar).HasName("PK__Confirma__AE39369F9FA1C28E");

            entity.ToTable("ConfirmarUsuario");

            entity.Property(e => e.IdConfirmar).HasColumnName("id_confirmar");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.IdSala).HasColumnName("id_sala");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.ConfirmarUsuarios)
                .HasForeignKey(d => d.IdSala)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Confirmar__id_sa__49C3F6B7");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ConfirmarUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Confirmar__id_us__48CFD27E");
        });

        modelBuilder.Entity<CrearSesion>(entity =>
        {
            entity.HasKey(e => e.IdSesion).HasName("PK__CrearSes__8D3F9DFE0491FFDA");

            entity.ToTable("CrearSesion");

            entity.Property(e => e.IdSesion).HasColumnName("id_sesion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaEncuentro)
                .HasColumnType("date")
                .HasColumnName("fecha_encuentro");
            entity.Property(e => e.IdDeporte).HasColumnName("id_deporte");
            entity.Property(e => e.IdLugar).HasColumnName("id_lugar");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.NombreSesion)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre_sesion");

            entity.HasOne(d => d.IdDeporteNavigation).WithMany(p => p.CrearSesions)
                .HasForeignKey(d => d.IdDeporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CrearSesi__id_de__3D5E1FD2");

            entity.HasOne(d => d.IdLugarNavigation).WithMany(p => p.CrearSesions)
                .HasForeignKey(d => d.IdLugar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CrearSesi__id_lu__3E52440B");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.CrearSesions)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CrearSesi__id_us__3C69FB99");
        });

        modelBuilder.Entity<Deporte>(entity =>
        {
            entity.HasKey(e => e.IdDeporte).HasName("PK__Deporte__05F136AFA544911B");

            entity.ToTable("Deporte");

            entity.Property(e => e.IdDeporte).HasColumnName("id_deporte");
            entity.Property(e => e.NombreDeporte)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre_deporte");
        });

        modelBuilder.Entity<Lugar>(entity =>
        {
            entity.HasKey(e => e.IdLugar).HasName("PK__Lugar__B172B1F8FF9D2095");

            entity.ToTable("Lugar");

            entity.Property(e => e.IdLugar).HasColumnName("id_lugar");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Direccion)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.NombreLugar)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre_lugar");
        });

        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK__Notifica__8270F9A5688F7772");

            entity.ToTable("Notificacion");

            entity.Property(e => e.IdNotificacion).HasColumnName("id_notificacion");
            entity.Property(e => e.Confirmacion).HasColumnName("confirmacion");
            entity.Property(e => e.IdUsuarioEmisor).HasColumnName("id_usuarioEmisor");
            entity.Property(e => e.IdUsuarioReceptor).HasColumnName("id_usuarioReceptor");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("mensaje");

            entity.HasOne(d => d.IdUsuarioEmisorNavigation).WithMany(p => p.NotificacionIdUsuarioEmisorNavigations)
                .HasForeignKey(d => d.IdUsuarioEmisor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificac__confi__412EB0B6");

            entity.HasOne(d => d.IdUsuarioReceptorNavigation).WithMany(p => p.NotificacionIdUsuarioReceptorNavigations)
                .HasForeignKey(d => d.IdUsuarioReceptor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificac__id_us__4222D4EF");
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.IdSala).HasName("PK__Sala__D18B015B1529611D");

            entity.ToTable("Sala");

            entity.Property(e => e.IdSala).HasColumnName("id_sala");
            entity.Property(e => e.CantidadUsuarios).HasColumnName("cantidad_usuarios");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdSesion).HasColumnName("id_sesion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdSesionNavigation).WithMany(p => p.Salas)
                .HasForeignKey(d => d.IdSesion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sala__id_sesion__44FF419A");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Salas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sala__id_usuario__45F365D3");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__4E3E04AD0C25782C");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Altura).HasColumnName("altura");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FechaNac)
                .HasColumnType("date")
                .HasColumnName("fecha_nac");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Pass)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("pass");
            entity.Property(e => e.Peso).HasColumnName("peso");
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("sexo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
