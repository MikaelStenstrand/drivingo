using UnityEngine;

[CreateAssetMenu(fileName = "BoolVariable", menuName = "Variables/Bool")]
public class BoolVariable : ScriptableObject, ISerializationCallbackReceiver {

    [Header("Value to be changed")]
    [SerializeField]
    private bool InitialValue;

    [Header("Debugging purposes")]
    [SerializeField]
    public bool RuntimeValue;

    public void OnAfterDeserialize() {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { }

}
