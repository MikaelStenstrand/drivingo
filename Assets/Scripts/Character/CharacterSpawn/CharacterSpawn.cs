using System;
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

    private void Awake()
    {
        if (enableSpawn)
        {
            StartCoroutine(SpawnCharactersCoroutine());
        }
    }

    private void Update()
    {
        // if enable spawn false --> true, start coroutine again
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

    private void SetCharacterLocationOnSpawn(GameObject characterGO)
    {
        characterGO.transform.position = gameObject.transform.position;
    }

    IEnumerator SpawnCharactersCoroutine()
    {
        yield return new WaitForSeconds(levelSpec.SpawnFrequencyInSeconds.Value);
        while (enableSpawn && (characterSpawnedAmount.Value < levelSpec.SpawnAmount.Value))
        {
            spawnCharacter();
            yield return new WaitForSeconds(levelSpec.SpawnFrequencyInSeconds.Value);
        }
    }


}
