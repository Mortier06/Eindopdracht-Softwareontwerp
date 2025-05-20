using WeerEventsApi.Observer;
using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Weerberichten
{
    public class WeerberichtManager : IObserver
    {
        private readonly List<Meting> _metingen = new();

        public void Update(Meting meting)
        {
            _metingen.Add(meting);
        }

        public void ToonWeerbericht()
        {
            var weerbericht = new Weerbericht(new List<Meting>(_metingen));
            Console.WriteLine(weerbericht.GeefInhoud());
        }
    }
}
