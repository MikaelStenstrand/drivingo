using Drivingo.Event;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Spec", menuName = "Specs/Ability")]
public class AbilitySpec : ScriptableObject
{
    [Header("General information")]
    public string Name;
    public string Description;
    public Sprite UISprite { get; private set; }
    public FloatReference DefaultSpeed;
    public FloatReference ActiveSpeed;
    public string Condition = "Character";
    [Header("Game Objects")]
    public GameObject CharacterPrefab;
    public GameObject AbilityControllerPrefab;
    public GameObject WaypointsPrefab;
    [Header("Events")]
    public GameEvent WaypointPlacementEvent;

    public void InitAbility()
    {
        GameObject GO = new GameObject("AbilityCreator", typeof(AbilityCreator));
        GO.GetComponent<AbilityCreator>().setAbilitySpec(this);
    }

}
