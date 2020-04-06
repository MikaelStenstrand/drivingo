using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreTextDisplay : MonoBehaviour
{
    [SerializeField]
    private LevelSpec levelSpec;

    [SerializeField]
    private FloatReference charactersReachedGoal;

    private TextMeshProUGUI textField;

    private void Awake()
    {
        textField = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        if (textField != null)
        {
            textField.text = $"{charactersReachedGoal.Value}/{levelSpec.TargetGoalAmount.Value}";
        }
    }
}
