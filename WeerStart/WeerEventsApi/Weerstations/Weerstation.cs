using System;
using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Observer;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations
{
    public class Weerstation : IObservable
    {
        public Stad Stad { get; set; }
        public StationType Type { get; set; }
        public List<Meting> Metingen { get; set; } = new List<Meting>();
        private List<IObserver> _observers = new List<IObserver>();
        public List<Meting> GeefMetingen()
        {
            return new List<Meting>(Metingen);
        } 
        public void DoeMeting()
        {
            double waarde;
            Eenheid eenheid;
            Random _random = new();

            switch (Type)
            {
                case StationType.Temperatuur:
                    waarde = _random.Next(-5, 41);
                    eenheid = Eenheid.GradenCelsius;
                    break;
                case StationType.Wind:
                    waarde = _random.Next(0, 100);
                    eenheid = Eenheid.KilometerPerUur;
                    break;
                case StationType.Luchtdruk:
                    waarde = _random.Next(950, 1050);
                    eenheid = Eenheid.HectoPascal;
                    break;
                case StationType.Neerslag:
                    waarde = _random.Next(0, 20);
                    eenheid = Eenheid.MillimeterPerVierkanteMeterPerUur;
                    break;
                default:
                    throw new InvalidOperationException("Onbekend type weerstation");
            }

            var meting = new Meting
            {
                TijdstipMeting = DateTime.Now,
                Waarde = Math.Round(waarde, 2),
                Eenheid = eenheid,
                Locatie = this.Stad
            };

            Metingen.Add(meting);

            Notify(meting);
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify(Meting meting)
        {
            foreach (var ob in _observers)
            {
                ob.Update(meting);
            }
        }

    }
}
