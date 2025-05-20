using WeerEventsApi.Observer;
using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Weerberichten
{
    public class Weerbericht : IWeerbericht
    {
        public string Inhoud;
        public DateTime Moment;
        
        

        public string GeefInhoud() => Inhoud;

        public DateTime GeefMoment() => Moment;

    }
}
