using Granamiza.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granamiza.Api.Infra.EntityMaps
{
    public class IncomeEntityMap
    {
        public IncomeEntityMap (EntityTypeBuilder<Income> builder)
        {
            builder.HasKey(income => income.Id);
            builder.Property(income => income.Title).IsRequired().HasMaxLength(100);
            builder.Property(income => income.Value).IsRequired();
            builder.Property(income => income.CreatedAt);
            builder.Ignore(income => income.Valid);
            builder.Ignore(income => income.ValidationResult);
        }
    }
}
