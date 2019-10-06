using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria_.Net_Core.Models;

namespace Inmobiliaria_.Net_Core.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Inmobiliaria_.Net_Core.Models.Propietario> propietarios { get; set; }
        public DbSet<Inmobiliaria_.Net_Core.Models.Inquilino> inquilino { get; set; }
        public DbSet<Inmobiliaria_.Net_Core.Models.Garante> garante { get; set; }
        public DbSet<Inmobiliaria_.Net_Core.Models.Inmueble> inmueble { get; set; }
        public DbSet<Inmobiliaria_.Net_Core.Models.Pago> pago { get; set; }
        public DbSet<Inmobiliaria_.Net_Core.Models.Alquiler> alquiler { get; set; }


    }
}
