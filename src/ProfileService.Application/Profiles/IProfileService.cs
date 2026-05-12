using ProfileService.Application.Profiles.Inputs;
using ProfileService.Application.Shared.Results;

namespace ProfileService.Application.Profiles;

public interface IProfileService
{
    Task<Result> CreateFromUserCreatedEventAsync(CreateFromUserCreatedEventInput input, CancellationToken ct = default);
}
