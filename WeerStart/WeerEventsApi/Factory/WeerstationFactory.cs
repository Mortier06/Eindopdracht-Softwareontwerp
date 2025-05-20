using System.Linq;
using WeerEventsApi.Steden;
using WeerEventsApi.Steden.Repositories;
using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Factory
{
    public class WeerstationFactory
    {

       

        public static List<Weerstation> MaakWeerstations()
        {
            Random _random = new();
            var stadRepo = new StadRepository();
            var steden = stadRepo.GetSteden().ToList();


            var stationTypes = Enum.GetValues(typeof(StationType)).Cast<StationType>().ToList();
            var weerstations = new List<Weerstation>();


            foreach (var stad in steden)
            {
                int index = _random.Next(stationTypes.Count);
                var type = stationTypes[index];

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
