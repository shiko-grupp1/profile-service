using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace ProfileService.Api.OpenApi;
// Provides an overall description of the API.
public sealed class OpenApiDocumentTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
        document.Components ??= new OpenApiComponents();

        document.Info.Title = "Profile Service API";
        document.Info.Version = "v1";
        document.Info.Description = """
        ## Introduction

        The Profile Service API provides endpoints for managing student and instructor profiles.
        
        When a new user is created in the Identity Service, a UserCreatedEvent is published to Azure Service Bus. The Profile Service listens for this event and automatically creates a corresponding profile in its own database.

        The API exposes endpoints for:
        - retrieving student profiles
        - retrieving instructor profiles
        - creating student profiles
        - creating instructor profiles
        - retrieving the currently authenticated user's profile
        """;

        return Task.CompletedTask;
    }
}
