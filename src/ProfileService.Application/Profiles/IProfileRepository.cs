using ProfileService.Domain.Entities.Profiles;

namespace ProfileService.Application.Profiles;

public interface IProfileRepository
{
    Task AddAsync(Profile profile, CancellationToken ct);
    Task<bool> ExistsByIdAsync(string userId, CancellationToken ct = default);
}
