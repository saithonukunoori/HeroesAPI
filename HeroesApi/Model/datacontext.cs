using Microsoft.EntityFrameworkCore;

namespace HeroesApi.Model
{
    public class datacontext :DbContext
    {
        public datacontext(DbContextOptions<datacontext> options ):base(options)
        {
            
        }
        public DbSet<Hero> Heroes { get; set; }
    }
}
