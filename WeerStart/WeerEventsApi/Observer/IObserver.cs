using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Observer
{
    public interface IObserver
    {
        void Update(Meting meting);
    }
}
