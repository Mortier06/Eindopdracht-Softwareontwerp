using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden.Managers;

namespace WeerEventsApi.Facade.Controllers;

public class DomeinController : IDomeinController
{
    private readonly IStadManager _stadManager;

    public DomeinController(IStadManager stadManager)
    {
        _stadManager = stadManager;
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
        //TODO
        throw new NotImplementedException();
    }

    public IEnumerable<MetingDto> GeefMetingen()
    {
        //TODO
        throw new NotImplementedException();
    }

    public void DoeMetingen()
    {
        //TODO
        throw new NotImplementedException();
    }

    public WeerBerichtDto GeefWeerbericht()
    {
        //TODO
        throw new NotImplementedException();
    }
}