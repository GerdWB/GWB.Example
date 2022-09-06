namespace GWB.Example.Web.Blazor.Configuration;

public class AppSettings
{
    public GrpcSettings Grpc { get; set; } = new();
}

public class GrpcSettings
{
    public string CountryServices { get; set; } = string.Empty;
}