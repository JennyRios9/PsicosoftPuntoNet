using Microsoft.EntityFrameworkCore;
using PsicosoftPuntoNet.Models;

namespace PsicosoftPuntoNet.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Pacientes> Paciente { get; set; }
    }
}
