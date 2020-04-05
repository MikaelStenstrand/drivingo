using UnityEngine;

public interface IGameTrigger
{
    FloatReference TargetAmount
    {
        get;
        set;
    }
    FloatReference CurrentAmount
    {
        get;
    }
    void OnTrigger(Collider2D collision);
    void OnTargetAmountTrigger();
}
