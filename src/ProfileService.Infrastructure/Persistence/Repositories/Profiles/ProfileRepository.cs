using Microsoft.EntityFrameworkCore;
using ProfileService.Application.Profiles;
using ProfileService.Domain.Entities.Profiles;
using ProfileService.Infrastructure.Persistence.Contexts;

namespace ProfileService.Infrastructure.Persistence.Repositories.Profiles;

public sealed class ProfileRepository(ProfileDbContext context) : IProfileRepository
{
    public async Task AddAsync(Profile profile, CancellationToken ct)
    {
        await context.Profiles.AddAsync(profile, ct);
    }

    public async Task<bool> ExistsByIdAsync(string userId, CancellationToken ct = default)
    {
        return await context.Profiles.AnyAsync(profile => profile.UserId == userId, ct);
    }
}
