using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Observer
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);
        void Notify(Meting meting);
    }
}
