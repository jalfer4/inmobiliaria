using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inmobiliariaMVC.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Propietario> Propietario { get; set; }
        public DbSet<Inmueble> Inmueble { get; set; }
        public DbSet<Inquilino> Inquilino { get; set; }
        public DbSet<Garante> Garante { get; set; }
        public DbSet<Alquiler> Alquiler { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }


    }
    public class Propietario
    {
        public int Id { get; set; }
        public ICollection<Inmueble> Inmueble { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }
        public Boolean EstaHabilitado { get; set; }
        public Boolean EstaPublicado { get; set; }

    }

    public class Inmueble
    {
        public int Id { get; set; }
        public Propietario Propietario { get; set; }
        public int PropietarioId { get; set; }
        public ICollection<Alquiler> Alquiler { get; set; }

        public string Direccion { get; set; }
        public enum Uso
        {
            Comercial,
            Residencia
        }
        public enum Tipo
        {
            Local,
            Casa,
            Departamento,
            Lote,
            Monoambiente,
            Depocito
        }
        public int Ambientes { get; set; }
        public Decimal Precio { get; set; }
        public enum Estado
        {
            Disponible,
            Alquilado,
            Vendido,
            Mantenimiento
        }

        public DateTime FechaAlta { get; set; }
        public Boolean EstaHabilitado { get; set; }
        public Boolean EstaPublicado { get; set; }

    }

    public class Inquilino
    {
        public int Id { get; set; }

        public ICollection<Pago> Pago { get; set; }
        public ICollection<Alquiler> Alquiler { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Trabajo { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }
        public Boolean EstaHabilitado { get; set; }
        public Boolean EstaPublicado { get; set; }

    }

    public class Pago
    {
        public int Id { get; set; }
        public Inquilino Inquilino { get; set; }
        public int InquilinoId { get; set; }
        public DateTime FechaAlta { get; set; }
        public decimal Monto { get; set; }


    }

    public class Alquiler
    {
        public int Id { get; set; }
        public Inmueble Inmueble { get; set; }
        public int InmuebleId { get; set; }
        public Inquilino Inquilino { get; set; }
        public int InquilinoId { get; set; }
        public Garante Garante { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public decimal Monto { get; set; }


    }

    public class Garante
    {
        public int Id { get; set; }
        public int AlquilerId { get; set; }
        public Alquiler Alquiler { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Trabajo { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }
        public Boolean EstaHabilitado { get; set; }
        public Boolean EstaPublicado { get; set; }

    }

}
