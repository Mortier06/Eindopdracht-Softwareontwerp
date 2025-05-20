using WeerEventsApi.Observer;
using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Weerberichten
{
    public class Weerbericht : IWeerbericht
    {
        private string Inhoud;
        private DateTime Moment;
        
        public Weerbericht(List<Meting> metingen)
        {
            Thread.Sleep(5000);
            Moment = DateTime.Now;

            var kansOpGoedWeer = metingen.Average(m => m.Waarde) < 50;
            var oordeel = kansOpGoedWeer ? "goed" : "slecht";

            Inhoud = $"Op basis van {metingen.Count} metingen en mijn diepzinnig computermodel kan ik zeggen dat er kans is op {oordeel} weer.";
        }

        public string GeefInhoud() => Inhoud;

        public DateTime GeefMoment() => Moment;

    }
}
