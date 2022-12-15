
using Microsoft.EntityFrameworkCore;


namespace BE_CRUDDonacion.Models
{
    public class AplicationDbContext: DbContext
    {

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {
        
        
        }

        public DbSet<Donacion> donaciones { get; set; } // nombre de la tabla
    }
}


