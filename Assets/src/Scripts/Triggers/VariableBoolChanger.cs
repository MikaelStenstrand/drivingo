using UnityEngine;

public class VariableBoolChanger : MonoBehaviour
{
    [SerializeField]
    private BoolReference variable;

    public void SetVariable(bool value)
    {
        variable.Value = value;
    }
}
