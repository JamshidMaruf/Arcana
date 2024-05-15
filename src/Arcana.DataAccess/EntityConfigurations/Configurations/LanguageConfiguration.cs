using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.Languages;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class LanguageConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    { }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // Language
        modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, Name = "English", ShortName = "EN", CreatedAt = DateTime.UtcNow },
                new Language { Id = 2, Name = "Spanish", ShortName = "ES", CreatedAt = DateTime.UtcNow });
    }
}