using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Logging;

public class MetingLogger : IMetingLogger
{
    public void Log(Meting message)
    {
        Console.WriteLine(message);
    }
}