using Cocktail.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cocktail.Infrastructure.Data.EntityConfigurations;

public sealed class CocktailEntityTypeConfiguration : EntityTypeConfiguration<Domain.Aggregates.Cocktail, Guid>
{
    public override void Configure(EntityTypeBuilder<Domain.Aggregates.Cocktail> entityTypeBuilder)
    {
        base.Configure(entityTypeBuilder);

        entityTypeBuilder
            .HasIndex(c => c.Name)
            .IsUnique();
    }
}