using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class TriggerAmountTextUpdaterUI : MonoBehaviour
{
    [SerializeField]
    private bool isGoal;

    private TextMeshPro textField;

    private IGameTrigger gameTrigger;

    private void Awake()
    {
        textField = gameObject.GetComponent<TextMeshPro>();
        gameTrigger = gameObject.GetComponentInParent<IGameTrigger>();
        if (gameTrigger == null)
        {
            throw new System.Exception("GameTriggern not found");
        }
    }

    private void Start()
    {
        UpdateText();
    }

    public void DestroyOnTime(float destroyTime)
    {
        Destroy(gameObject, destroyTime);
    }

    private void UpdateText()
    {
        if (gameTrigger != null)
        {
            if (gameTrigger.CurrentAmount.Value <= gameTrigger.TargetAmount.Value)
            {
                textField.text = $"{gameTrigger.CurrentAmount.Value.ToString()}/{gameTrigger.TargetAmount.Value.ToString()}";
            }
            else
            {
                string prefix = isGoal ? "+" : "-";
                textField.text = $"{prefix}{(gameTrigger.CurrentAmount.Value - gameTrigger.TargetAmount.Value).ToString()}";
            }
        }
    }




}
