using System;
using AccesoDatos.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AccesoDatos.Contexto
{
    public class ReparacionesContexto : DbContext
    {
        public virtual  DbSet<Diagnostico> Diagnosticos { get; set; }   
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<EstadoReparacion> EstadoReparaciones { get; set; }
        public virtual DbSet<Propietario> Propietarios { get; set;}
        public virtual DbSet<Reparacion> Reparaciones { get; set;}
        public virtual DbSet<Vehiculo> Vehiculos { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity
                        .ToTable("Vehiculos");
                entity
                        .HasKey(v => v.SerialVehiculo);
                entity
                        .Property(v => v.IdPropietario)
                        .HasAnnotation("coment", "El id del propietario");
                entity
                        .Property(v => v.FechaCrea)
                        .HasComment("Fecha en la que se Crea el vehiculo")
                entity
                        .Property(v => v.FechaModifica)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComment("Fecha en que se modifica un dato");
                entity
                        .Property(v => v.Marca)
                        .HasMaxLength(45)
                        .HasComment("La maraca del vehiculo");
                entity
                        .Property(v => v.Modelo)
                        .HasMaxLength(45)
                        .HasComment("El modelo del vehiculo");
                entity
                        .Property(v => v.Placa)
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasComment("La placa del vehiculo");
                entity
                        .HasOne(c => c.Propietario)
                        .WithMany(o => o.Vehiculos)
                        .HasForeignKey(c => c.IdPropietario);                  
            });

            modelBuilder.Entity<Reparacion>(entity =>
            {
                entity
                        .ToTable("Reparacines");
                entity
                        .HasKey(r => r.IdReparacion);
                entity
                        .Property(r => r.IdEstadoReparacion)
                        .HasComment("El Id del estado en que se encuentra la reparacion");
                entity
                        .Property(r => r.IdPropietario)
                        .HasComment("El id de la reparación");
                entity
                        .Property(r => r.FechaIngreso)
                        .HasComment("Fecha en la que ingresa el vehiculo");
                entity
                        .Property(r => r.FechaSalida)
                        .HasComment("Fecha en la que termina la reparacion del vehiculo");
                entity
                        .Property(r => r.SerialVehiculo)
                        .HasComment("Serial del vehiculo que estan reparando.");                
                entity
                        .HasOne(c => c.EstadoReparacion)
                        .WithMany(o => o.Reparaciones)
                        .HasForeignKey(c => c.IdEstadoReparacion);
                entity
                        .HasOne(c => c.Vehiculo)
                        .WithMany(o => o.Reparaciones)
                        .HasForeignKey(c => c.SerialVehiculo);
            });

            modelBuilder.Entity<Diagnostico>(entity =>
            {
                entity.ToTable("Diagnosticos");
                entity.HasKey(d => d.IdDiagnostico);
                entity.Property(d => d.IdDiagnostico).HasComment("El id del Diagnostico");
                entity.Property(d => d.IdEmpleado).HasComment("El id del empleado que diagnostica");
                entity.Property(d => d.IdReparacion).HasComment("El id de la Reparacion");
                entity.Property(d => d.Descripcion).HasComment("La descripcion del daño segun el propietario");
                entity.Property(d => d.Resultados).HasComment("El resultado del diagnostico del vehiculo");
                entity.Property(d => d.fechaCrea).HasComment("La fecha en la que se crea el diagnostico");
                entity
                        .HasOne(c => c.Empleado)
                        .WithMany(o => o.Diagnosticos)
                        .HasForeignKey(c => c.IdEmpleado);
                entity
                        .HasOne(c => c.Reparaciones)
                        .WithMany(o => o.Diagnosticos)
                        .HasForeignKey(c => c.IdReparacion);
            });

            modelBuilder.Entity<EstadoReparacion>(entity =>
            {
                entity.ToTable("EstadoReparaciones");
                entity.HasKey(er => er.IdEstadoReparacion);
                entity.Property(er => er.Nombre).HasComment("Nombre que describe el estado");
                entity.Property(er => er.Descripcion).HasComment("Descripcion del estado");
                entity.Property(er => er.FechaCrea).HasComment("Fecha en la que se crea el estado");
            });
            
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("Empleados");
                entity.HasKey(e => e.IdEmpleado);
                entity.Property(e => e.Nombre).HasComment("Nombre del empleado");
                entity.Property(e => e.Apellido).HasComment("Apellido del empleado");
                entity.Property(e => e.Usuario).HasComment("Usuario del empleado");
                entity.Property(e => e.Contrasena).HasComment("Contraseña del empleado");
                entity.Property(e => e.FechaCrea).HasComment("Fecha en la que se crea el estado");
            });

            modelBuilder.Entity<Propietario>(entity =>
            {
                entity
                        .ToTable("Propietarios");
                entity
                        .HasKey(p => p.IdPropietario);
                entity
                        .Property(p => p.IdPropietario)
                        .HasComment("Nombre del propietario");
                entity
                        .Property(p => p.Nombre)
                        .IsRequired()
                        .HasComment("Nombre del propietario");
                entity
                        .Property(p => p.Apellido)
                        .IsRequired()
                        .HasComment("Apellido del propietario");
                entity
                        .Property(p => p.Telefono)
                        .HasComment("Telefono del propietario");
                entity
                        .Property(p => p.Correo)
                        .IsRequired()
                        .HasComment("telefono del propietario");
                entity
                        .Property(p => p.Direccion)
                        .HasComment("Direcion del propietario");
            })
            
                base.OnModelCreating(modelBuilder);
        }
    }
}
