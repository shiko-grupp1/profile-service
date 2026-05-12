using ProfileService.Application.Profiles.Inputs;
using ProfileService.Application.Shared;
using ProfileService.Application.Shared.Results;
using ProfileService.Domain.Entities.Profiles;

namespace ProfileService.Application.Profiles;

public sealed class ProfileManager(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileService
{
    public async Task<Result> CreateFromUserCreatedEventAsync(CreateFromUserCreatedEventInput input, CancellationToken ct = default)
    {
        // skyddar mot programmeringsfel, felaktiga anrop
        if (input is null)
            return Result.Failure(ErrorTypes.BadRequest, "Input cannot be null.");

        if (string.IsNullOrWhiteSpace(input.UserId))
            return Result.Failure(ErrorTypes.BadRequest, "UserId is required.");

        if (string.IsNullOrWhiteSpace(input.FirstName))
            return Result.Failure(ErrorTypes.BadRequest, "First name is required.");

        if (string.IsNullOrWhiteSpace(input.LastName))
            return Result.Failure(ErrorTypes.BadRequest, "Last name is required.");

        try
        {
            bool exists = await profileRepository.ExistsByIdAsync(input.UserId);

            if (exists)
                return Result.Failure(ErrorTypes.Conflict, $"A profile with UserId: {input.UserId} already exists.");

            Profile profile = Profile.Create(input.UserId, input.FirstName, input.LastName);

            await profileRepository.AddAsync(profile, ct);
            await unitOfWork.SaveChangesAsync(ct);

            return Result.Success();
        }
        catch (Exception ex) 
        {
            string exceptionDetails = ex.Message;
            return Result.Failure(ErrorTypes.InternalServerError, $"Could not create profile. Details: {exceptionDetails}");
        }
       
    }
}

