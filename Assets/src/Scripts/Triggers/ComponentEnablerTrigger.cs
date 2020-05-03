using UnityEngine;

public class ComponentEnablerTrigger : MonoBehaviour
{
    [SerializeField]
    private Behaviour[] components;
    [SerializeField]
    private BoolReference enabler;

    private bool prevState;

    private void Start()
    {
        prevState = !enabler.Value;
    }

    private void Update()
    {
        if (HasValueChanged())
        {
            foreach (var component in components)
            {
                component.enabled = enabler.Value;
            }

            prevState = enabler.Value;
        }
    }

    private bool HasValueChanged()
    {
        return enabler.Value != prevState;
    }
}
