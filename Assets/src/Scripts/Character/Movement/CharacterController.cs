using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(CharacterInfo))]
public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float movementAmplifier = 10;

    private CharacterInfo characterInfo;
    private CharacterMovement characterController;
    private CharacterState characterState;

    private void Awake()
    {
        characterInfo = GetComponent<CharacterInfo>();
        characterController = GetComponent<CharacterMovement>();
    }

    private void Start()
    {
        characterState = CharacterState.WALKING;
    }

    public void SetCharacterState(CharacterState state)
    {
        characterState = state;
    }

    private void FixedUpdate()
    {
        if (characterState == CharacterState.WALKING)
        {
            characterController.Move(GetHorizontalSpeed(), false, false);
        }
        else if (characterState == CharacterState.IN_QUEUE)
        {
            characterController.Move(0.0f, false, false);
        }
    }

    private float GetHorizontalSpeed()
    {
        // basic forward walking for now
        return characterInfo.WalkingSpeed * movementAmplifier * Time.fixedDeltaTime;
    }

}
