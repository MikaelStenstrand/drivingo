using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Spec", menuName = "Specs/Level")]
public class LevelSpec : ScriptableObject
{
    public CharacterSpec Character = null;
    public FloatReference SpawnAmount = new FloatReference() { Value = 5.0f };
    public FloatReference SpawnFrequencyInSeconds = new FloatReference() { Value = 5.0f };

    // To be added later
    // time countdown
    // abilities[]
}
