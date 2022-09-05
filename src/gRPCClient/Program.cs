using Grpc.Net.Client.Web;

var loggerFactory = LoggerFactory.Create(logging =>
{
    logging.AddConsole();
    logging.SetMinimumLevel(LogLevel.Trace);
});

// Erstelle neuen HttpClient mit GrpcWebHandler
var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));

// Konfiguriere die Server URL
var channel = GrpcChannel.ForAddress("https://localhost:7106",
    new GrpcChannelOptions
    {
        HttpClient = httpClient,
        LoggerFactory = loggerFactory
    });

var countryClient = new CountryGrpcServiceClient(channel);
var resultCall = countryClient.GetAll(new Empty());


Console.ReadLine();