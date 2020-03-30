using UnityEngine;

[CreateAssetMenu(fileName = "New Character Spec", menuName = "Specs/Character")]
public class CharacterSpec : ScriptableObject
{
    [SerializeField]
    private FloatReference walkingSpeed;

    [SerializeField]
    private GameObject prefab;


    public GameObject Initialize()
    {
        GameObject characterGO = Instantiate(prefab);
        CharacterInfo characterInfo = characterGO.GetComponent<CharacterInfo>();

        characterInfo.WalkingSpeed = walkingSpeed;
        return characterGO;
    }


}
