using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EnsaioRegional.Models;

namespace EnsaioRegional.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EnsaioRegional.Models.DataEnsaio> DataEnsaio { get; set; }
        public DbSet<EnsaioRegional.Models.Igreja> Igreja { get; set; }
        public DbSet<EnsaioRegional.Models.TipoInstrumento> TipoInstrumento { get; set; }
        public DbSet<EnsaioRegional.Models.Instrumento> Instrumento { get; set; }
        public DbSet<EnsaioRegional.Models.Musico> Musico { get; set; }
        public DbSet<EnsaioRegional.Models.Presenca> Presenca { get; set; }
    }
}