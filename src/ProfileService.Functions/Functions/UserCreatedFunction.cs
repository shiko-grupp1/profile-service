using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using ProfileService.Application.Profiles;
using ProfileService.Application.Profiles.Inputs;
using ProfileService.Contracts.Events;
using System.Text.Json;

namespace ProfileService.Functions.Functions;

public class UserCreatedFunction(IProfileService profileService, CancellationToken ct = default)
{
    private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
    };

    [Function(nameof(UserCreatedFunction))]
    public async Task Run(
        [ServiceBusTrigger("%UserCreatedQueueName%", Connection = "AzureServiceBusConnection")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        string body = message.Body.ToString();

        UserCreatedEvent? userCreatedEvent = JsonSerializer.Deserialize<UserCreatedEvent>(body, _jsonOptions)
            ?? throw new InvalidOperationException("Message could not be deserialized");

        if (!IsValid(userCreatedEvent))
            throw new InvalidOperationException("Message is missing required fields.");

        CreateFromUserCreatedEventInput input = new(userCreatedEvent.UserId, userCreatedEvent.FirstName, userCreatedEvent.LastName);

        await profileService.CreateFromUserCreatedEventAsync(input, ct);

        // Complete the message
        await messageActions.CompleteMessageAsync(message);
    }

    private static bool IsValid(UserCreatedEvent userCreatedEvent)
    {
        if (string.IsNullOrWhiteSpace(userCreatedEvent.UserId)) return false;
        if (string.IsNullOrWhiteSpace(userCreatedEvent.FirstName)) return false;
        if (string.IsNullOrWhiteSpace(userCreatedEvent.LastName)) return false;

        return true;
    }
}