using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Logging;

public interface IMetingLogger
{
    void Log(Meting message);
}