using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ProfileService.Functions.Functions;

public class UserCreatedFunction
{
    private readonly ILogger<UserCreatedFunction> _logger;

    public UserCreatedFunction(ILogger<UserCreatedFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(UserCreatedFunction))]
    public async Task Run(
        [ServiceBusTrigger("%UserCreatedQueueName%", Connection = "AzureServiceBusConnection")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        _logger.LogInformation("Message ID: {id}", message.MessageId);
        _logger.LogInformation("Message Body: {body}", message.Body);
        _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

        // Complete the message
        await messageActions.CompleteMessageAsync(message);
    }
}