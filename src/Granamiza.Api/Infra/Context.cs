using Granamiza.Api.Infra.EntityMaps;
using Granamiza.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Granamiza.Api.Infra
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options) : base(options)
        {
        }

#nullable disable
        public DbSet<Income> Incomes { get; set; }
#nullable restore

        protected override void OnModelCreating (ModelBuilder builder)
        {
            _ = new IncomeEntityMap(builder.Entity<Income>());

        }
    }
}
