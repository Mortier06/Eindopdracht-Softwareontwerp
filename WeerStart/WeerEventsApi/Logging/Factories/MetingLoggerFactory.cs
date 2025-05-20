using WeerEventsApi.Decorators;

namespace WeerEventsApi.Logging.Factories;

public static class MetingLoggerFactory
{
    public static IMetingLogger Create(bool decorateWithJson, bool decorateWithXml)
    {
        IMetingLogger logger = new MetingLogger();

        if (decorateWithXml)
        {
            logger = new XmlDecorator(logger);
        }
        if (decorateWithJson)
        {
            logger = new JsonDecorator(logger);
        }
        return logger;
    }
}