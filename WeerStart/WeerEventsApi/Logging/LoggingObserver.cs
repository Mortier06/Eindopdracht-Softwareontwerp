using System;
using WeerEventsApi.Observer;
using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Logging
{
    public class LoggingObserver : IObserver
    {
        private IMetingLogger _logger;

        public LoggingObserver(IMetingLogger logger)
        {
            _logger = logger;
        }

        public void Update(Meting meting)
        {
            _logger.Log(meting);
        }
    }
}
