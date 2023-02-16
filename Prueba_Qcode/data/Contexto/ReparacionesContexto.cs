using System;
using AccesoDatos.Modelos;
using Microsoft.EntityFrameworkCore;

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
            //Relacion de entidades
            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity
                        .HasOne(c => c.Propietario)
                        .WithMany(o => o.Vehiculos)
                        .HasForeignKey(c => c.IdPropietario);                  
            });
            modelBuilder.Entity<Reparacion>(entity =>
            {
                entity
                        .HasOne(c => c.EstadoReparacion)
                        .WithMany(o => o.Reparaciones)
                        .HasForeignKey(c => c.IdEstadoReparacion);
                entity
                        .HasOne(c => c.Vehiculo)
                        .WithMany(o => o.Reparaciones)
                        .HasForeignKey(c => c.IdReparacion);
            });
            modelBuilder.Entity<Diagnostico>(entity =>
            {
                entity
                        .HasOne(c => c.Empleado)
                        .WithMany(o => o.Diagnosticos)
                        .HasForeignKey(c => c.IdEmpleado);
                entity
                        .HasOne(c => c.Reparaciones)
                        .WithMany(o => o.Diagnosticos)
                        .HasForeignKey(c => c.IdReparacion);
            });

            //convension de nomenclarura

            //Restricciones

            base.OnModelCreating(modelBuilder);
        }
    }
}
