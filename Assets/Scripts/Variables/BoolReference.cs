
[System.Serializable]
public class BoolReference {

    public bool UseConstant = true;
    public bool ConstantValue;
    public BoolVariable Variable;

    public bool Value {
        get {
            return UseConstant ? ConstantValue : Variable.RuntimeValue;
        } 
        set {
            if(UseConstant) {
                ConstantValue = value;
            } else {
                Variable.RuntimeValue = value;
            }
        }
    }

}
