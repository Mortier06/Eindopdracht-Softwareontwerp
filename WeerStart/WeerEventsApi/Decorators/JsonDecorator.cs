using System.Text.Json;
using WeerEventsApi.Logging;
using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Decorators
{
    public class JsonDecorator : IMetingLogger
    {
        private IMetingLogger _logger;
        private string pad = "log.json";

        public JsonDecorator(IMetingLogger logger)
        {
            _logger = logger;
        }

        public void Log(Meting meting)
        {
            var jsonLog = new
            {
                meting.TijdstipMeting,
                meting.Eenheid,
                meting.Waarde,
                Locatie = new
                {
                    meting.Locatie.Naam,
                    meting.Locatie.Beschrijving,
                    meting.Locatie.GekendVoor
                }
            };

            var options = new JsonSerializerOptions();
            options.WriteIndented = true;

            string jsonString = JsonSerializer.Serialize(jsonLog, options) + Environment.NewLine;

            File.AppendAllText(pad, jsonString);
            _logger.Log(meting);
        }
    }

}
