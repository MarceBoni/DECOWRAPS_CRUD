using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DECOWRAPS_CRUD.Models
{
    public partial class DECOWRAPSContext : DbContext
    {
        public DECOWRAPSContext()
        {
        }

        public DECOWRAPSContext(DbContextOptions<DECOWRAPSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catalogo> Catalogos { get; set; }
        public virtual DbSet<CatalogoCliente> CatalogoClientes { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Despacho> Despachos { get; set; }
        public virtual DbSet<DetalleOrden> DetalleOrdens { get; set; }
        public virtual DbSet<OrdenDecowrap> OrdenDecowraps { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<Transportadora> Transportadoras { get; set; }
        public virtual DbSet<Vendedor> Vendedors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-1LV2Q8B;Database=DECOWRAPS;User ID=sa;Password=Sa1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Catalogo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodCatalogo).HasColumnName("cod_catalogo");

                entity.Property(e => e.CodProducto).HasColumnName("cod_producto");

                entity.Property(e => e.DesProducto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("des_producto");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_actualizacion");

                entity.Property(e => e.Precio)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("precio");

                entity.HasOne(d => d.CodCatalogoNavigation)
                    .WithMany(p => p.Catalogos)
                    .HasForeignKey(d => d.CodCatalogo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catalogos_Catalogo_cliente");

                entity.HasOne(d => d.CodProductoNavigation)
                    .WithMany(p => p.Catalogos)
                    .HasForeignKey(d => d.CodProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catalogos_Producto");
            });

            modelBuilder.Entity<CatalogoCliente>(entity =>
            {
                entity.HasKey(e => e.CodCatalogo);

                entity.ToTable("Catalogo_cliente");

                entity.Property(e => e.CodCatalogo).HasColumnName("cod_catalogo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_vencimiento");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.CatalogoClientes)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catalogo_cliente_Cliente");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("celular")
                    .IsFixedLength(true);

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("ciudad");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("email");

                entity.Property(e => e.NoIdentificacion).HasColumnName("No_identificacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pais");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("telefono")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Despacho>(entity =>
            {
                entity.HasKey(e => e.IdDespacho);

                entity.ToTable("Despacho");

                entity.Property(e => e.IdDespacho).HasColumnName("id_despacho");

                entity.Property(e => e.CiudadDestino)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ciudad_destino");

                entity.Property(e => e.DireccionDestino)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("direccion_destino");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdOrden).HasColumnName("id_orden");

                entity.Property(e => e.IdTransportador).HasColumnName("id_transportador");

                entity.Property(e => e.NoGuia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("no_guia");

                entity.Property(e => e.NomDestinatario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nom_destinatario");

                entity.Property(e => e.PaisDestino)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pais_destino");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.Despachos)
                    .HasForeignKey(d => d.IdOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Despacho_ORDEN_DECOWRAPS");

                entity.HasOne(d => d.IdTransportadorNavigation)
                    .WithMany(p => p.Despachos)
                    .HasForeignKey(d => d.IdTransportador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Despacho_Transportadora");
            });

            modelBuilder.Entity<DetalleOrden>(entity =>
            {
                entity.HasKey(e => e.IdDetalleorden);

                entity.ToTable("Detalle_orden");

                entity.Property(e => e.IdDetalleorden).HasColumnName("id_detalleorden");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CodProducto).HasColumnName("cod_producto");

                entity.Property(e => e.DesProducto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("des_producto");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdOrden).HasColumnName("id_orden");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("precio_unitario");

                entity.Property(e => e.Total)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.DetalleOrdens)
                    .HasForeignKey(d => d.IdOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detalle_orden_ORDEN_DECOWRAPS");
            });

            modelBuilder.Entity<OrdenDecowrap>(entity =>
            {
                entity.HasKey(e => e.IdOrden);

                entity.ToTable("ORDEN_DECOWRAPS");

                entity.Property(e => e.IdOrden).HasColumnName("Id_orden");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

                entity.Property(e => e.NoGuia)
                    .HasMaxLength(50)
                    .HasColumnName("no_guia");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre_cliente");

                entity.Property(e => e.NombreVendedor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre_vendedor");

                entity.Property(e => e.Total)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.OrdenDecowraps)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDEN_DECOWRAPS_Cliente");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.OrdenDecowraps)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDEN_DECOWRAPS_Vendedor");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodProducto);

                entity.ToTable("Producto");

                entity.Property(e => e.CodProducto).HasColumnName("cod_producto");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.DesProducto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("des_producto");

                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");

                entity.Property(e => e.Precio)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("referencia");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Proveedor");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.ToTable("Proveedor");

                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("celular");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Nit).HasColumnName("nit");

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("razon_social");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Transportadora>(entity =>
            {
                entity.HasKey(e => e.IdTransportador);

                entity.ToTable("Transportadora");

                entity.Property(e => e.IdTransportador).HasColumnName("id_transportador");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("celular");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Nit).HasColumnName("nit");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.PaginaWeb)
                    .HasMaxLength(50)
                    .HasColumnName("pagina_web");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.IdVendedor);

                entity.ToTable("Vendedor");

                entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("celular");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("telefono");

                entity.Property(e => e.Zona)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("zona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
