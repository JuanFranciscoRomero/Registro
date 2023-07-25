using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegistrodeEmpleado.Models;

namespace RegistrodeEmpleado.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Beneficios> beneficios { get; set; }
        public DbSet<Cargos> cargos { get; set; }
        public DbSet<Empleado> empleados { get; set; }
        public DbSet<Habilidades> habilidades { get; set; }
        public DbSet<Proyectos> proyectos { get; set; }
    }
}