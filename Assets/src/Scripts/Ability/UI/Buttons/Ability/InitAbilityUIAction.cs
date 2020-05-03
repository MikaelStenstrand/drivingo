using UnityEngine;

public class InitAbilityUIAction : MonoBehaviour
{
    [SerializeField]
    private AbilitySpec abilitySpec;

    public void InitAbility()
    {
        abilitySpec.InitAbility();
    }
}
