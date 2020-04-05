using UnityEngine;

public class GameEventListener : MonoBehaviour
{

    [SerializeField]
    private GameEvent gameEvent;

    [SerializeField]
    private UnityEventParams response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        if (gameEvent == null)
        {
            return;
        }
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(params object[] parameters)
    {
        response.Invoke(parameters);
    }
}
