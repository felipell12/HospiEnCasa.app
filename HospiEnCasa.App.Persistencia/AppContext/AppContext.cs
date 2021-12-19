using Microsoft.EntityFrameworkCore;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> personas { get; set; }
        public DbSet<Enfermera> enfermeras { get; set; }
        public DbSet<FamiliarDesignado> familiaresdesignados { get; set; }
        public DbSet<Historia> historias { get; set; }
        public DbSet<Medico> medicos { get; set; }
        public DbSet<Paciente> pacientes { get; set; }
        public DbSet<SignoVital> signosvitales { get; set; }
        public DbSet<SugerenciaCuidado> sugerenciascuidados { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DBHospienCasa3;integrated security=true");
            }
        }

    }
}