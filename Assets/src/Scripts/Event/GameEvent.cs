using System.Collections.Generic;
using UnityEngine;

namespace Drivingo.Event
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Event/Game Event")]
    public class GameEvent : ScriptableObject, IGameEvent
    {

        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise(params object[] parameters)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(parameters);
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}