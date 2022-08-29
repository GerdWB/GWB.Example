namespace GWB.Example.Application.Core.Domain;

public record Country(
    Guid Id, 
    string Name, 
    string Description, 
    byte[]? FlagImage, 
    DateTime Created, 
    DateTime? Updated);