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
    // placement effect
    private string condition = "Player";

    // abilityInitStates[]
    // speed
    // movementTrajectory

    private Vector3 positionOutsideOfScreen;

    private void OnEnable()
    {
        positionOutsideOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void InitAbility()
    {
        GameObject GO = Instantiate(characterPrefab, positionOutsideOfScreen, Quaternion.identity);
        GO.AddComponent(typeof(AbilityCreator));
    }

}
