namespace ProfileService.Contracts.Events;

public sealed record UserCreatedEvent
(
    string UserId,
    string FirstName,
    string LastName
);


