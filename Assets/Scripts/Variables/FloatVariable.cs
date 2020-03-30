using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "Variables/Float")]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver {

    [Header("Value to be changed")]
    [SerializeField]
    private float InitialValue;

    [Header("Debugging purposes")]
    [SerializeField]
    public float RuntimeValue;

    public void OnAfterDeserialize() {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { }

}
