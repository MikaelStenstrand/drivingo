using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Spec", menuName = "Specs/Ability")]
public class AbilitySpec : ScriptableObject
{
    [SerializeField]
    new private string name;
    [SerializeField]
    private string description;
    [SerializeField]
    private Sprite UISprite;
    [SerializeField]
    private GameObject characterPrefab;
    // placement effect
    private string condition = "Player";

    public bool UseAbility()
    {
        Debug.Log("USE ABILITY");

        return true;
    }



}
