using Microsoft.EntityFrameworkCore;
using OhMyPops.Models;

namespace OhMyPops.Data
{
    public class OhMyPopsContext : DbContext
    {
        public OhMyPopsContext(DbContextOptions<OhMyPopsContext> options) : base(options)
        {

        }

        public DbSet<Pop> Pops { get; set; }
    }
}