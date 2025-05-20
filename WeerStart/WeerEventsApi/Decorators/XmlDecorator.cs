using WeerEventsApi.Logging;
using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Decorators
{
    public class XmlDecorator : IMetingLogger
    {
        private IMetingLogger _logger;
        private string pad = "log.xml";

        public XmlDecorator(IMetingLogger logger)
        {
            _logger = logger;
        }

        public void Log(Meting meting)
        {
            string xmlString =
                "<Meting>\n" +
                $"  <Moment>{meting.TijdstipMeting}</Moment>\n" +
                $"  <Waarde>{meting.Waarde}</Waarde>\n" +
                $"  <Eenheid>{meting.Eenheid}</Eenheid>\n" +
                "</Meting>\n";

            File.AppendAllText(pad, xmlString + Environment.NewLine);
            _logger.Log(meting);
        }
    }
}
