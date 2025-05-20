using System.Linq;
using WeerEventsApi.Steden;
using WeerEventsApi.Steden.Repositories;
using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Factory
{
    public class WeerstationFactory
    {

        private static readonly Random _random = new();

        public static List<Weerstation> MaakWeerstations()
        {
            var stadRepo = new StadRepository();
            var steden = stadRepo.GetSteden().ToList();


            var stationTypes = Enum.GetValues(typeof(StationType)).Cast<StationType>().ToList();
            var weerstations = new List<Weerstation>();


            foreach (var stad in steden)
            {
                var type = stationTypes[_random.Next(stationTypes.Count)];

                var weerstation = new Weerstation
                {
                    Stad = stad,
                    Type = type
                };

                weerstations.Add(weerstation);
            }

            return weerstations;
        }
    }
}
