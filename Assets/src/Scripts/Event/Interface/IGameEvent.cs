namespace Drivingo.Event
{
    public interface IGameEvent
    {
        void Raise(params object[] parameters);
        void RegisterListener(GameEventListener listener);
        void UnregisterListener(GameEventListener listener);
    }
}