namespace ProfileService.Application.Profiles.Inputs;

public sealed record CreateFromUserCreatedEventInput
(
    string UserId,
    string FirstName,
    string LastName
);
