using TechnicoApplication.Models;

namespace TechnicoApplication.Responses;

public record ImmutableResponseStatus(bool status, string? message, IPrintable? printable = null){
    public void PrintResponseStatus() => Console.WriteLine($"Status: {status}");
    public void PrintResponseMessage() => Console.WriteLine($"Message: {message}");
    public void PrintObjectData() => printable?.PrintSelf();
};
