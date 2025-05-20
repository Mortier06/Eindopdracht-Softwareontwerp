using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Weerberichten;
using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Facade.Controllers;

public class DomeinController : IDomeinController
{
    private readonly IStadManager _stadManager;
    private List<Weerstation> _weerstations;
    private WeerberichtManager _weerberichtManager;

    public DomeinController(IStadManager stadManager, List<Weerstation> weerstations, WeerberichtManager weerberichtManager)
    {
        _stadManager = stadManager;
        _weerstations = weerstations;
        _weerberichtManager = weerberichtManager;
    }

    public IEnumerable<StadDto> GeefSteden()
    {
        return _stadManager.GeefSteden().Select(s => new StadDto
        {
            Naam = s.Naam,
            Beschrijving = s.Beschrijving,
            GekendVoor = s.GekendVoor
        });
    }

    public IEnumerable<WeerStationDto> GeefWeerstations()
    {
        return _weerstations.Select(ws => new WeerStationDto
        {
            StadNaam = ws.Stad.Naam,
            Type = ws.Type.ToString()
        });
    }

    public IEnumerable<MetingDto> GeefMetingen()
    {
        return _weerstations
        .SelectMany(ws => ws.GeefMetingen())
        .Select(m => new MetingDto
        {
            Moment = m.TijdstipMeting,
            Waarde = m.Waarde,
            Eenheid = m.Eenheid.ToString(),
            Stad = m.Locatie.Naam
        });
    }

    public void DoeMetingen()
    {
        foreach (var ws in _weerstations)
        {
            ws.DoeMeting();
        }
    }

    public WeerBerichtDto GeefWeerbericht()
    {
        var metingen = _weerstations.SelectMany(ws => ws.GeefMetingen()).ToList();
        var weerbericht = _weerberichtManager.MaakWeerbericht(metingen);

        return new WeerBerichtDto
        {
            Inhoud = weerbericht.GeefInhoud(),
            Moment = weerbericht.GeefMoment()
        };
    }
}