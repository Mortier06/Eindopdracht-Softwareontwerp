using WeerEventsApi.Facade.Controllers;
using WeerEventsApi.Factory;
using WeerEventsApi.Logging;
using WeerEventsApi.Logging.Factories;
using WeerEventsApi.Observer;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Steden.Repositories;
using WeerEventsApi.Weerberichten;
using WeerEventsApi.Weerstations;

var builder = WebApplication.CreateBuilder(args);

// Maak dependencies aan
var metingLogger = MetingLoggerFactory.Create(decorateWithJson: true, decorateWithXml: true);
var weerberichtManager = new WeerberichtManager();
var logger = new LoggingObserver(metingLogger);
var weerstations = WeerstationFactory.MaakWeerstations();

// Subscribe observers op weerstations
foreach (var ws in weerstations)
{
    ws.Subscribe(logger);
    ws.Subscribe(weerberichtManager);
}

// Voeg alle services toe
builder.Services.AddSingleton<IMetingLogger>(metingLogger);
builder.Services.AddSingleton<IObserver>(logger);
builder.Services.AddSingleton(weerberichtManager);
builder.Services.AddSingleton<List<Weerstation>>(weerstations);
builder.Services.AddSingleton<IStadRepository, StadRepository>();
builder.Services.AddSingleton<IStadManager, StadManager>();
builder.Services.AddSingleton<IDomeinController, DomeinController>();

// Bouw de app
var app = builder.Build();

// API-routes
app.MapGet("/", () => "WEER - WEERsomstandigheden Evalueren En Rapporteren");
app.MapGet("/steden", (IDomeinController dc) => dc.GeefSteden());
app.MapGet("/weerstations", (IDomeinController dc) => dc.GeefWeerstations());
app.MapGet("/metingen", (IDomeinController dc) => dc.GeefMetingen());
app.MapPost("/commandsmetingen", (IDomeinController dc) => dc.DoeMetingen());
app.MapGet("/weerbericht", (IDomeinController dc) => dc.GeefWeerbericht());

app.Run();
