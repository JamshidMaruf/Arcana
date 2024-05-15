using Microsoft.EntityFrameworkCore;

namespace Arcana.DataAccess.EntityConfigurations.Commons;

public interface IEntityConfiguration
{
    void Configure(ModelBuilder modelBuilder);
    void SeedData(ModelBuilder modelBuilder);
}