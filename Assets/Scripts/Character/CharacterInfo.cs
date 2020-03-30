﻿using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    private FloatReference walkingSpeed = new FloatReference() { Value = 0 };

    public float WalkingSpeed { get => walkingSpeed.Value; set => walkingSpeed.Value = value; }
}