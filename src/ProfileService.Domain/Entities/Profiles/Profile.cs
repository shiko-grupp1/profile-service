using ProfileService.Domain.Exceptions.Custom;
using ProfileService.Domain.Helpers;

namespace ProfileService.Domain.Entities.Profiles;

public sealed class Profile
{
    public Guid Id { get; private set; }
    public string UserId { get; private set; }

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string? PhoneNumber { get; private set; }
    public string? Description { get; private set; }

    public string? AvatarUrl { get; private set; }
    public string? CoverImageUrl { get; private set; }
    public string? Bio { get; private set; }

    private Profile() { }

    private Profile(Guid id, string userId, string firstName, string lastName)
    {
        Id = id;
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
    }

    public static Profile Create(string userId, string firstName, string lastName)
    {
        string normalizedUserId = ValidationHelpers.ValidateString(userId, nameof(userId));
        string normalizedFirstName = ValidationHelpers.ValidateString(firstName, nameof(firstName));
        string normalizedLastName = ValidationHelpers.ValidateString(lastName, nameof(lastName));

        return new Profile(Guid.NewGuid(), normalizedUserId, normalizedFirstName, normalizedLastName);
    }


    public void SetPhoneNumber(string? phoneNumber)
    {
        phoneNumber = ValidationHelpers.ValidateOptionalString(phoneNumber, nameof(phoneNumber), 30);

        if (phoneNumber is not null && !ValidationHelpers.IsValidPhoneNumber(phoneNumber))
            throw new ValidationDomainException("PhoneNumber has an invalid format.");

        PhoneNumber = phoneNumber;
    }

    public void SetDescription(string? description)
    {
        Description = ValidationHelpers.ValidateOptionalString(description, nameof(description), 500);
    }

    public void SetAvatarUrl(string? avatarUrl)
    {
        avatarUrl = ValidationHelpers.ValidateOptionalString(avatarUrl, nameof(avatarUrl), 500);

        if (avatarUrl is not null && !ValidationHelpers.IsValidUrl(avatarUrl))
            throw new ValidationDomainException("AvatarUrl has an invalid format.");

        AvatarUrl = avatarUrl;
    }

    public void SetCoverImageUrl(string? coverImageUrl)
    {
        coverImageUrl = ValidationHelpers.ValidateOptionalString(coverImageUrl, nameof(coverImageUrl), 500);

        if (coverImageUrl is not null && !ValidationHelpers.IsValidUrl(coverImageUrl))
            throw new ValidationDomainException("CoverImageUrl has an invalid format.");

        CoverImageUrl = coverImageUrl;
    }

    public void SetBio(string? bio)
    {
        Bio = ValidationHelpers.ValidateOptionalString(bio, nameof(bio), 1000);
    }



}