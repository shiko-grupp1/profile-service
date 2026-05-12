using Microsoft.EntityFrameworkCore;
using ProfileService.Application.Shared;
using ProfileService.Domain.Entities.Profiles;

namespace ProfileService.Infrastructure.Persistence.Contexts;

public class ProfileDbContext(DbContextOptions<ProfileDbContext> options) : DbContext(options), IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProfileDbContext).Assembly);
    }

    public DbSet<Profile> Profiles => Set<Profile>();

}
