using Drivingo.Event;
using UnityEngine;


public class SimpleEventRaiseTrigger : MonoBehaviour
{
    [SerializeField]
    private GameEvent eventToRaise;

    public void RaiseEvent()
    {
        if (eventToRaise != null)
        {
            eventToRaise.Raise();
        }
    }
    public void RaiseEvent(object[] args)
    {
        if (eventToRaise != null)
        {
            eventToRaise.Raise(args);
        }
    }
}
