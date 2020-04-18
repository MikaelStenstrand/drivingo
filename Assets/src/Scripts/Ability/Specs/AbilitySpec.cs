using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Spec", menuName = "Specs/Ability")]
public class AbilitySpec : ScriptableObject
{
    [SerializeField]
    new private string name;
    [SerializeField]
    private string description;
    public Sprite UISprite { get; private set; }
    [SerializeField]
    private GameObject characterPrefab;
    [SerializeField]
    private FloatReference defaultSpeed;
    [SerializeField]
    private FloatReference activeSpeed;


    // placement effect
    private string condition = "Character";

    private Vector3 positionOutsideOfScreen;

    private void OnEnable()
    {
        positionOutsideOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void InitAbility()
    {
        GameObject GO = Instantiate(characterPrefab, positionOutsideOfScreen, Quaternion.identity);
        AbilityCreator abilityCreator = GO.AddComponent(typeof(AbilityCreator)) as AbilityCreator;
        abilityCreator.condition = condition;
    }

}
