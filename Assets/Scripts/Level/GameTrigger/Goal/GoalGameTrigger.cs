using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GoalGameTrigger : MonoBehaviour, IGameTrigger
{
    [SerializeField]
    private LevelSpec levelSpec;

    public float TargetAmount { get => levelSpec.TargetGoalAmount.Value; set => levelSpec.TargetGoalAmount.Value = value; }
    public float CurrentAmount { get; private set; } = 0;

    [SerializeField]
    private GameEvent triggerEvent;

    [SerializeField]
    private GameEvent targetAmountTriggerEvent;

    const string CHARATER_TAG = "Character";

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
        CurrentAmount++;
        if (CurrentAmount >= TargetAmount)
        {
            OnTargetAmountTrigger();
        }
        triggerEvent.Raise();
    }
}
