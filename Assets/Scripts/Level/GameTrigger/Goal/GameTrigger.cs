using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GameTrigger : MonoBehaviour, IGameTrigger
{
    [SerializeField]
    private LevelSpec levelSpec;

    public FloatReference TargetAmount;
    FloatReference IGameTrigger.TargetAmount { get => TargetAmount; set => TargetAmount = value; }

    public FloatReference CurrentAmount;
    FloatReference IGameTrigger.CurrentAmount => CurrentAmount;


    [SerializeField]
    private GameEvent triggerEvent;

    [SerializeField]
    private GameEvent targetAmountTriggerEvent;

    const string CHARATER_TAG = "Character";

    private void Awake()
    {
        if (TargetAmount.Value <= 0)
        {
            TargetAmount = levelSpec.TargetGoalAmount;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == CHARATER_TAG)
        {
            OnTrigger(collision);
        }
    }

    public void OnTargetAmountTrigger()
    {
        targetAmountTriggerEvent.Raise();
    }

    public void OnTrigger(Collider2D collision)
    {
        CurrentAmount.Value++;
        if (CurrentAmount.Value >= TargetAmount.Value)
        {
            OnTargetAmountTrigger();
        }
        triggerEvent.Raise();
    }
}
