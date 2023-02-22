using Qcode.Datos.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace Qcode.Datos.Contexto
{
    public class ReparacionesContext: DbContext
    {

        public ReparacionesContext(DbContextOptions<ReparacionesContext> options) : base(options) { }
        public virtual DbSet<Diagnostico> Diagnosticos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<EstadoReparacion> EstadoReparacion { get; set; }
        public virtual DbSet<Reparacion> Reparaciones { get; set; }
        public virtual DbSet<Propietario> Propietarios { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Propiedades
            modelBuilder.Entity("Qcode.Datos.Modelos.Diagnostico", b =>
            {
                b.Property<long>("IdDiagnostico")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");

                b.Property<string>("Descripcion")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                b.Property<DateTime>("FechaCrea")
                    .HasColumnType("datetime(6)");

                b.Property<string>("IdEmpleado")
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                b.Property<long>("IdReparacion")
                    .HasColumnType("bigint");

                b.Property<string>("Resultados")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                b.HasKey("IdDiagnostico");

                b.HasIndex("IdEmpleado");

                b.HasIndex("IdReparacion");

                b.ToTable("Diagnosticos");
            });

            modelBuilder.Entity("Qcode.Datos.Modelos.Empleado", b =>
            {
                b.Property<string>("IdEmpleado")
                    .HasColumnType("varchar(255)");

                b.Property<string>("Apellido")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.Property<string>("Contrasena")
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");

                b.Property<DateTime>("FechaCrea")
                    .HasColumnType("datetime(6)");

                b.Property<string>("Nombre")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.Property<string>("Usuario")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.HasKey("IdEmpleado");

                b.ToTable("Empleados");
            });

            modelBuilder.Entity("Qcode.Datos.Modelos.EstadoReparacion", b =>
            {
                b.Property<long>("IdEstadoReparacion")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");

                b.Property<string>("Descripcion")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.Property<DateTime>("FechaCrea")
                    .HasColumnType("datetime(6)");

                b.Property<string>("Nombre")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.HasKey("IdEstadoReparacion");

                b.ToTable("EstadoReparacion");
            });

            modelBuilder.Entity("Qcode.Datos.Modelos.Propietario", b =>
            {
                b.Property<string>("IdPropietario")
                    .HasColumnType("varchar(255)");

                b.Property<string>("Apellido")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.Property<string>("Correo")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.Property<string>("Direccion")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.Property<DateTime>("FechaCrea")
                    .HasColumnType("datetime(6)");

                b.Property<string>("Nombre")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.Property<string>("Telefono")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.HasKey("IdPropietario");

                b.ToTable("Propietarios");
            });

            modelBuilder.Entity("Qcode.Datos.Modelos.Reparacion", b =>
            {
                b.Property<long>("IdReparacion")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");

                b.Property<DateTime>("FechaCrea")
                    .HasColumnType("datetime(6)");

                b.Property<DateTime>("FechaSale")
                    .HasColumnType("datetime(6)");

                b.Property<long>("IdEstadoReparacion")
                    .HasColumnType("bigint");

                b.Property<string>("SerialVehiculo")
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                b.HasKey("IdReparacion");

                b.HasIndex("IdEstadoReparacion");

                b.HasIndex("SerialVehiculo");

                b.ToTable("Reparaciones");
            });

            modelBuilder.Entity("Qcode.Datos.Modelos.Vehiculo", b =>
            {
                b.Property<string>("SerialVehiculo")
                    .HasColumnType("varchar(255)");

                b.Property<DateTime>("FechaCrea")
                    .HasColumnType("datetime(6)");

                b.Property<string>("IdPropietario")
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                b.Property<string>("Marca")
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)");

                b.Property<string>("Modelo")
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)");

                b.Property<string>("Placa")
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnType("varchar(10)");

                b.HasKey("SerialVehiculo");

                b.HasIndex("IdPropietario");

                b.ToTable("Vehiculos");
            });

            //Relaciones
            modelBuilder.Entity("Qcode.Datos.Modelos.Diagnostico", b =>
            {
                b.HasOne("Qcode.Datos.Modelos.Empleado", "Empleados")
                    .WithMany("Diagnosticos")
                    .HasForeignKey("IdEmpleado")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Qcode.Datos.Modelos.Reparacion", "Reparaciones")
                    .WithMany("Diagnosticos")
                    .HasForeignKey("IdReparacion")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Empleados");

                b.Navigation("Reparaciones");
            });

            modelBuilder.Entity("Qcode.Datos.Modelos.Reparacion", b =>
            {
                b.HasOne("Qcode.Datos.Modelos.EstadoReparacion", "EstadoReparaciones")
                    .WithMany("Reparaciones")
                    .HasForeignKey("IdEstadoReparacion")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Qcode.Datos.Modelos.Vehiculo", "Vehiculos")
                    .WithMany("Reparaciones")
                    .HasForeignKey("SerialVehiculo")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("EstadoReparaciones");

                b.Navigation("Vehiculos");
            });

            modelBuilder.Entity("Qcode.Datos.Modelos.Vehiculo", b =>
            {
                b.HasOne("Qcode.Datos.Modelos.Propietario", "Propietarios")
                    .WithMany("Vehiculos")
                    .HasForeignKey("IdPropietario")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Propietarios");
            });

            //Navegacion
            modelBuilder.Entity("Qcode.Datos.Modelos.Empleado", b =>
            {
                b.Navigation("Diagnosticos");
            });

            modelBuilder.Entity("Qcode.Datos.Modelos.EstadoReparacion", b =>
            {
                b.Navigation("Reparaciones");
            });

            modelBuilder.Entity("Qcode.Datos.Modelos.Propietario", b =>
            {
                b.Navigation("Vehiculos");
            });

            modelBuilder.Entity("Qcode.Datos.Modelos.Reparacion", b =>
            {
                b.Navigation("Diagnosticos");
            });

            modelBuilder.Entity("Qcode.Datos.Modelos.Vehiculo", b =>
            {
                b.Navigation("Reparaciones");
            });
        }


    }
}
