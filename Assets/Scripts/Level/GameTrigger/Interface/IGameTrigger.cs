using UnityEngine;

public interface IGameTrigger
{
    float TargetAmount
    {
        get;
        set;
    }
    float CurrentAmount
    {
        get;
    }
    void OnTrigger(Collider2D collision);
    void OnTargetAmountTrigger();
}
