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

        public Weerbericht MaakWeerbericht(List<Meting> metingen)
        {
            string tekst = "";

            if (metingen.Count != 0)
            {
                Thread.Sleep(5000); // Simuleer zwaar model

                int aantalMetingen = metingen.Count;
                bool isGoedWeer = CheckWeer(metingen);

                if (isGoedWeer)
                {
                    tekst = $"Op basis van {aantalMetingen} metingen en mijn diepzinnig computermodel kan ik zeggen dat er kans is op goed weer.";
                }
                else
                {
                    tekst = $"Op basis van {aantalMetingen} metingen en mijn diepzinnig computermodel kan ik zeggen dat er kans is op slecht weer.";
                }
            }
            else
            {
                tekst = "Er zijn nog geen metingen gedaan";
            }

            return new Weerbericht
            {
                Moment = DateTime.Now,
                Inhoud = tekst
            };
        }

        public bool CheckWeer(List<Meting> metingen)
        {
            if (metingen.Count == 0)
            {
                return false;
            }

            //checken of de waarden niet te veel of te weinig zijn
            bool luchtdrukOk = false;
            bool neerslagOk = false;
            bool tempOk = false;
            bool windOk = false;

            //gemiddelde 
            double gemLuchtdruk = 0;
            double gemNeerslag = 0;
            double gemTemp = 0;
            double gemWind = 0;

            //totaal om later gemiddelde te berekenen
            double totLuchtdruk = 0;
            double totNeerslag = 0;
            double totTemp = 0;
            double totWind = 0;

            //aantal keer voorgekomen
            double countLuchtdruk = 0;
            double countNeerslag = 0;
            double countTemp = 0;
            double countWind = 0;

            foreach (var meting in metingen)
            {
                if (meting.Eenheid == Eenheid.HectoPascal)
                {
                    countLuchtdruk++;
                    totLuchtdruk += meting.Waarde;
                }
                else if (meting.Eenheid == Eenheid.MillimeterPerVierkanteMeterPerUur)
                {
                    countNeerslag++;
                    totNeerslag += meting.Waarde;
                }
                else if (meting.Eenheid == Eenheid.GradenCelsius)
                {
                    countTemp++;
                    totTemp += meting.Waarde;
                }
                else if (meting.Eenheid == Eenheid.KilometerPerUur)
                {
                    countWind++;
                    totWind += meting.Waarde;
                }
            }

            if (countLuchtdruk != 0)
            {
                gemLuchtdruk = totLuchtdruk / countLuchtdruk;
            }
            if (countNeerslag != 0)
            {
                gemNeerslag = totNeerslag / countNeerslag;
            }
            if (countTemp != 0)
            {
                gemTemp = totTemp / countTemp;
            }
            if (countWind != 0)
            {
                gemWind = totWind / countWind;
            }

            if (gemLuchtdruk > 1000 && gemLuchtdruk < 1020)
            {
                luchtdrukOk = true;
            }
            if (gemNeerslag <= 4)
            {
                neerslagOk = true;
            }
            if (gemTemp > 10 && gemTemp < 35)
            {
                tempOk = true;
            }
            if (gemWind <= 40)
            {
                windOk = true;
            }

            return (luchtdrukOk && neerslagOk && tempOk && windOk);
        }

        
    }
}
