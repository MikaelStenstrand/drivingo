using System.Collections;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    [SerializeField]
    private LevelSpec levelSpec;
    [SerializeField]
    private bool enableSpawn = true;
    [SerializeField]
    private FloatReference characterSpawnedAmount;

    private bool coroutineActive = false;

    private void Update()
    {
        if (ContinueCoroutine() && !coroutineActive)
        {
            StartCoroutine(SpawnCharactersCoroutine());
        }
    }

    private void spawnCharacter()
    {
        GameObject characterGO = levelSpec.Character.Initialize();
        if (characterGO != null)
        {
            SetCharacterLocationOnSpawn(characterGO);
            characterSpawnedAmount.Value += 1;
        }
    }

    private bool ContinueCoroutine()
    {
        return enableSpawn && (characterSpawnedAmount.Value < levelSpec.SpawnAmount.Value);
    }

    private void SetCharacterLocationOnSpawn(GameObject characterGO)
    {
        characterGO.transform.position = gameObject.transform.position;
    }

    IEnumerator SpawnCharactersCoroutine()
    {
        coroutineActive = true;
        yield return new WaitForSeconds(levelSpec.SpawnFrequencyInSeconds.Value);
        while (ContinueCoroutine())
        {
            spawnCharacter();
            yield return new WaitForSeconds(levelSpec.SpawnFrequencyInSeconds.Value);
        }
        coroutineActive = false;
    }


}
