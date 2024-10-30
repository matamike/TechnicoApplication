namespace TechnicoApplication.Responses;

public record ImmutableResponseStatus(bool status, string? message, object? data = null);
