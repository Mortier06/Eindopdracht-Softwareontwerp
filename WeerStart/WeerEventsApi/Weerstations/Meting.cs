using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations
{
    public class Meting
    {
        public DateTime TijdstipMeting { get; set; }
        public double Waarde {  get; set; }
        public Eenheid Eenheid { get; set; }
        public Stad Locatie { get; set; }
    }
}
